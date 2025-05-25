using System.Text.Json.Serialization;

namespace TicketService.Models.StripePayment
{
    public class StripeEvent
    {
        [JsonPropertyName("id")]
        public required string Id { get; set; }

        [JsonPropertyName("type")]
        public required string Type { get; set; }

        [JsonPropertyName("data")]
        public required StripeData Data { get; set; }
    }
}
