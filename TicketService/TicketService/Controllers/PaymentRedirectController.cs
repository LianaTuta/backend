using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using TicketService.BL.Interface;
using TicketService.Models.Configuration;
using TicketService.Models.Exceptions;
using TicketService.Models.StripePayment;

namespace TicketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentRedirectController : ControllerBase
    {
        private readonly IPaymentResponseService _paymentResponseService;
        private readonly StripeCredentials _stripeCredentials;

        public PaymentRedirectController(
            IOptions<StripeCredentials> stripeCredentials,
            IPaymentResponseService paymentResponseService)
        {
            _stripeCredentials = stripeCredentials.Value;
            _paymentResponseService = paymentResponseService;
        }

        [HttpPost("webhook")]
        public async Task UpdatePaymentAsync()
        {
            string json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            try
            {
                Event stripeEvent = EventUtility.ConstructEvent(
                    json,
                    Request.Headers["Stripe-Signature"],
                    _stripeCredentials.WebhookSecret
                );
                StripeEvent? stripePaymentEvent = JsonSerializer.Deserialize<StripeEvent>(json);

                await _paymentResponseService.UpdatePaymentAsync(stripePaymentEvent);

            }
            catch (StripeException)
            {
                throw new CustomException("Service Unavailable", HttpStatusCode.ServiceUnavailable);
            }
        }
    }
}
