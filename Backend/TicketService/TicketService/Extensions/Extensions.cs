

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using RepoDb;
using System.Data;
using System.Text;
using TicketService.Middleware;
using TicketService.Models;


namespace TicketService.Extensions
{

    public static class Extensions
    {
        public static IServiceCollection AddAuthentificationForWebApp(this IServiceCollection service, IConfiguration configuration)
        {
            JwtSettingsModel? jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettingsModel>();
            _ = service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.ValidIssuer,
                        ValidAudience = jwtSettings.ValidAudience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                    };

                });

            return service;
        }

        public static IServiceCollection AddDatabaseConnection(this IServiceCollection service, IConfiguration configuration)
        {
            _ = service.AddTransient<IDbConnection>(sp =>
                 new SqlConnection(configuration.GetConnectionString("DefaultConnection")));
            GlobalConfiguration.Setup().UseSqlServer();
            return service;
        }

        public static IApplicationBuilder UserMiddleware(this IApplicationBuilder builder)
        {
           
            builder.UseMiddleware<ExceptionMiddleware>();
            return builder;
        }
    }
}
