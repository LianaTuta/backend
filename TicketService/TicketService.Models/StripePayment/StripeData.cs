using System.Text.Json.Serialization;

namespace TicketService.Models.StripePayment
{
    public class StripeData
    {
        [JsonPropertyName("object")]
        public required StripeCheckoutSession Object { get; set; }
    }
}
