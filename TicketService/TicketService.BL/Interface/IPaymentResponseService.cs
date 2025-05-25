using TicketService.Models.StripePayment;

namespace TicketService.BL.Interface
{
    public interface IPaymentResponseService
    {

        Task UpdatePaymentAsync(StripeEvent stripeEvent);

    }
}
