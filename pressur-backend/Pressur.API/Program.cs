using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using System.Globalization;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Pressur.API.Configurations;
using Pressur.API.Filters;
using Pressur.API.Responses;
using Pressur.Data;
using Pressur.Domain;
using Pressur.Identity;
using Pressur.Application;
using Serilog;

const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

System.Console.WriteLine("Ambiente: " + builder.Environment.EnvironmentName);
ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddFeatureManagement();

//Add AddSerilog
LogConfiguration.AddSerilog(builder.Configuration);
builder.Host.UseSerilog(Log.Logger);

builder.Services.AddBootstrapData(builder.Configuration);
builder.Services.AddBootstrapDomain();
builder.Services.AddBootstrapUseCase();
builder.Services.AddBootstrapIdentity(builder.Configuration);
builder.Services.AddBootstrapIntegrationTests();

builder.Services.AddFluentValidationAutoValidation(configuration =>
{
    configuration.DisableBuiltInModelValidation = true;
    configuration.OverrideDefaultResultFactoryWith<CustomResultFactory>();
});


// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins(
                              "http://localhost:4200",
                              "https://localhost:4200",
                              "http://localhost:4200/",
                              "https://localhost:4200/")
                            .SetIsOriginAllowedToAllowWildcardSubdomains()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AdicionarSwaggerConfig();

builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddMvc(x =>
{
    x.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
    x.Filters.Add<ExceptionFilter>();
    x.Filters.Add<HeadersFilter>();
    x.Filters.Add(new ProducesResponseTypeAttribute(typeof(ErrorResponse), StatusCodes.Status400BadRequest));
    x.Filters.Add(new ProducesResponseTypeAttribute(typeof(ErrorResponse), StatusCodes.Status500InternalServerError));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Tests"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}


app.UseCors(myAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();