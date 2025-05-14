using Microsoft.AspNetCore.Mvc;
using TicketService.ApiClient.Interface;

namespace TicketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayPalResponseController : ControllerBase
    {
        private readonly IPayPalClient _client;
        public PayPalResponseController(IPayPalClient client)
        {
            _client = client;
        }
        [HttpPost("create-payment")]
        public async Task<string> CreatePaymentAsync()
        {
            return await Task.FromResult(_client.CreatePayment(10));
        }

        [HttpPost("checkout")]
        public async Task OrderAsync()
        {

            // Read the request body (the webhook payload)
            _ = await new System.IO.StreamReader(Request.Body).ReadToEndAsync();

            // Validate the webhook to ensure it's from PayPal (you may need to implement signature validation)
            _ = Request.Headers["Paypal-Transmission-Sig"];
            /* var webhookId = _configuration["PayPal:WebhookId"];
             var verificationResult = WebhookEvent.ValidateReceivedEvent(signature, body, webhookId);

             if (!verificationResult)
             {
                 return Unauthorized();  // Return 401 if signature verification fails
             }
            */
            // Parse the webhook event payload
            /* var webhookEvent = WebhookEvent.Deserialize(body);

             // Handle the events
             switch (webhookEvent.event_type)
             {
                 case "PAYMENT.SALE.COMPLETED":
                     Sale sale = webhookEvent.resource as Sale;
                     if (sale.state == "completed")
                     {

                     }
                     break;

                 case "PAYMENT.SALE.PENDING":
                     // Handle pending payment (if applicable)
                     break;

                 case "PAYMENT.SALE.DENIED":
                     // Handle denied payment (if applicable)
                     break;

                 default:
                     break;
             }

             return Ok();  // Return 200 OK to PayPal after processing the event
         }
         catch (Exception ex)
         {
             // Log error and return 500
             return StatusCode(500, "Error processing webhook: " + ex.Message);
         */
        }
    }
}
