using PayPal;
using PayPal.Api;
using TicketService.ApiClient.Interface;

namespace TicketService.ApiClient.Implementation
{
    public class PayPalClient : IPayPalClient
    {
        private readonly APIContext _context;

        public PayPalClient(APIContext context)
        {
            _context = context;
        }

        public string? CreatePayment(decimal amount)
        {
            Payment payment = new()
            {
                intent = "sale",
                payer = new Payer() { payment_method = "paypal" },
                transactions =
        [
            new Transaction()
            {
                description = "Payment for services",
                amount = new Amount()
                {
                    currency = "USD",
                    total = amount.ToString("0.00")
                }
                }
                ],
                redirect_urls = new RedirectUrls()
                {
                    return_url = "http://localhost:3000/event-details/1007",  // URL to redirect after success
                    cancel_url = "http://localhost:3000/event-details/1008"   // URL to redirect after cancellation
                }
            };

            try
            {
                Payment createdPayment = payment.Create(_context);
                string? approvalUrl = createdPayment.links.FirstOrDefault(x => x.rel == "approval_url")?.href;

                if (!string.IsNullOrEmpty(approvalUrl))
                {
                    return approvalUrl;  // Return the approval URL
                }
            }
            catch (PayPalException ex)
            {
                // Handle PayPal exceptions here
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
            return null;
        }


    }
}
