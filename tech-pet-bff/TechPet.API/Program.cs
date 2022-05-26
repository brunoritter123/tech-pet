using Microsoft.AspNetCore.Mvc;
using TechPet.API.Filters;
using TechPet.API.Results;
using TechPet.Startup;

var builder = WebApplication.CreateBuilder(args);
builder.AddBootstrapStartup();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
    x.Filters.Add<ResultFilter>();
    x.Filters.Add<ExceptionFilter>();
    x.Filters.Add(new ProducesResponseTypeAttribute(typeof(ResultDefault), StatusCodes.Status400BadRequest));
    x.Filters.Add(new ProducesResponseTypeAttribute(typeof(ResultDefault), StatusCodes.Status500InternalServerError));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
