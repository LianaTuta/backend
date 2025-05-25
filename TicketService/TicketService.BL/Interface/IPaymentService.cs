using TicketService.Models.ResponseModels;

namespace TicketService.BL.Interface
{
    public interface IPaymentService
    {
        Task<OrderResponseModel> CreatePaymentAsync(int userId, int checkoutOrderId);
    }
}
