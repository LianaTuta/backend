using System.Text.Json.Serialization;

namespace TicketService.Models.StripePayment
{
    public class StripeCheckoutSession
    {
        [JsonPropertyName("payment_intent")]
        public required string PaymentIntent { get; set; }

        [JsonPropertyName("id")]
        public required string PaymentId { get; set; }

        [JsonPropertyName("status")]
        public required string SessionStatus { get; set; }

        [JsonPropertyName("payment_status")]
        public required string PaymentStatus { get; set; }
    }
}
