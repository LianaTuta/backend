using TicketService.Models.ResponseModels;
using TicketService.Models.StripePayment;

namespace TicketService.BL.Interface
{
    public interface IPaymentService
    {
        Task<OrderResponseModel> CreatePaymentAsync(int userId, int checkoutOrderId);
        Task UpdatePaymentAsync(StripeEvent stripeEvent);
    }
}
