using TicketService.Models.RequestModels.Order;
using TicketService.Models.ResponseModels;

namespace TicketService.BL.Interface
{
    public interface ICheckoutService
    {
        Task<OrderResponseModel> ProcessOrderAsync(int userId, CheckoutRequest checkout);
        Task CancelOrderAsync(int userId, int checkoutOrderId);

        Task CancelExpiredOrdersAsync();
        Task<ValidTicketModel> IsValidTicket(int ticketId);

    }
}
