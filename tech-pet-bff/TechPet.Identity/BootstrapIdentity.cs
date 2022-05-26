using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TechPet.Identity.Data;
using TechPet.Identity.DTOs;
using TechPet.Identity.Entities;
using TechPet.Identity.Interfaces;
using TechPet.Identity.Services;

namespace TechPet.Identity
{
    public static class BootstrapIdentity
    {
        public static IServiceCollection AddBootstrapIdentity(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddScoped<IIdentityService, IdentityService>();
            ConfigureIdentity(service);
            ConfigureJwt(service, configuration);
            return service;
        }

        private static void ConfigureIdentity(IServiceCollection services)
        {
            IdentityBuilder builder = services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services);
            builder.AddEntityFrameworkStores<DbContext>();
            builder.AddRoleValidator<RoleValidator<Role>>();
            builder.AddRoleManager<RoleManager<Role>>();
            builder.AddSignInManager<SignInManager<User>>();
            builder.AddDefaultTokenProviders();

            // services.AddAuthorization(options =>
            // {
            //     options.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
            // });
        }

        private static void ConfigureJwt(IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("TokenConfig");
            services.Configure<TokenConfigDto>(appSettingsSection);

            var tokenConfig = appSettingsSection.Get<TokenConfigDto>();

            var key = Encoding.ASCII.GetBytes(tokenConfig.JwtSecretKey);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                //x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = tokenConfig.Audience,
                    ValidIssuer = tokenConfig.Issuer
                };
            });
        }
    }
}
