

using System.Data;
using System.Text;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using PayPal.Api;
using RepoDb;
using TicketService.Middleware;
using TicketService.Models.Configuration;


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

        public static IServiceCollection AddDatabaseConnection(this IServiceCollection services, IConfiguration configuration)
        {
            RetrieveDatabaseConnection(configuration);
            _ = services.AddTransient<IDbConnection>(sp =>
                 new SqlConnection(configuration.GetConnectionString("DefaultConnection")));
            _ = GlobalConfiguration.Setup().UseSqlServer();
            return services;
        }


        public static IApplicationBuilder UserMiddleware(this IApplicationBuilder builder)
        {

            _ = builder.UseMiddleware<ResponseMiddleware>();
            _ = builder.UseMiddleware<ExceptionMiddleware>();

            return builder;
        }

        public static IServiceCollection AddClientGoogle(this IServiceCollection services, IConfiguration configuration)
        {
            string bucketcredentials = SecretManagerExtension.GetSecret("Bucket-Credentials");
            _ = services.AddTransient(provider =>
            {

                GoogleCredential credential = GoogleCredential.FromJson(bucketcredentials);
                return StorageClient.Create(credential);
            });
            _ = services.AddTransient(provider =>
            {
                GoogleCredential credential = GoogleCredential.FromJson(bucketcredentials);
                return UrlSigner.FromCredential(credential);
            });

            return services;
        }

        public static IServiceCollection AddClientPayPal(this IServiceCollection services, IConfiguration configuration)
        {
            _ = services.AddTransient(provider =>
            {
                PayPalSettings? settings = configuration.GetSection("PayPal").Get<PayPalSettings>();
                Dictionary<string, string> config = new()
                {
                    { "clientId", settings.ClientId },
                    { "clientSecret", settings.Secret },
                    { "mode", settings.Mode }
                }
                ;
                string accessToken = new OAuthTokenCredential(settings.ClientId, settings.Secret, config).GetAccessToken();
                APIContext apiContext = new(accessToken);
                return apiContext;
            });

            return services;
        }

        private static void RetrieveDatabaseConnection(IConfiguration configuration)
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
            string secretName = environment == "Development" ? "Sql-Connection-String-Local" : "Sql-Connection-String";
            configuration["ConnectionStrings:DefaultConnection"] = SecretManagerExtension.GetSecret(secretName);
        }
    }
}
