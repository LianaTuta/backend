using System.Text;
using System.Text.Json;
using Google.Cloud.SecretManager.V1;

namespace TicketService.Extensions
{
    public static class SecretManagerExtension
    {
        private static readonly SecretManagerServiceClient _client = SecretManagerServiceClient.Create();

        private static string GetProjectId()
        {
            return Environment.GetEnvironmentVariable("GOOGLE_CLOUD_PROJECT")
                       ?? throw new InvalidOperationException("GOOGLE_CLOUD_PROJECT environment variable not set.");
        }

        public static string GetSecret(string secretName)
        {
            string projectId = GetProjectId();
            SecretVersionName secret = new(projectId, secretName, "latest");
            AccessSecretVersionResponse result = _client.AccessSecretVersion(secret);
            return result.Payload.Data.ToStringUtf8();
        }

        public static void InjectJsonSecretAsConfigSection(WebApplicationBuilder builder, string secretName, string configSection)
        {
            string json = GetSecret(secretName);

            IConfigurationRoot parsed = new ConfigurationBuilder()
                .AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(json)))
                .Build();

            foreach (KeyValuePair<string, string?> kvp in parsed.AsEnumerable())
            {
                if (kvp.Value != null)
                {
                    builder.Configuration[kvp.Key] = kvp.Value;
                }
            }
        }
        public static T BindSecretToObject<T>(string secretName)
        {
            string json = GetSecret(secretName);
            return JsonSerializer.Deserialize<T>(json)
                   ?? throw new InvalidOperationException($"Failed to bind secret {secretName} to {typeof(T).Name}");
        }


    }
}
