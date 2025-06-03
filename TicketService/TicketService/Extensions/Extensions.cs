using System.Text;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
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
            _ = services.AddScoped<NpgsqlConnection>(sp =>
            {
                NpgsqlConnection connection = new(configuration.GetConnectionString("DefaultConnection"));

                connection.Open();
                return connection;
            });



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
        public static void AddStripe(IConfiguration configuration)
        {
            StripeCredentials? stripeCredentials = configuration.GetSection("StripeCredentials").Get<StripeCredentials>();
            Stripe.StripeConfiguration.ApiKey = stripeCredentials.SecretKey;
        }

        private static void RetrieveDatabaseConnection(IConfiguration configuration)
        {
            configuration["ConnectionStrings:DefaultConnection"] = SecretManagerExtension.GetSecret("ConnectionStringPostgresSql");
        }
    }
}
