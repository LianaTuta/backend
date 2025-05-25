using TicketService.Models.RequestModels.Order;

namespace TicketService.BL.Interface
{
    public interface IOrderService
    {
        Task<int> InsertDefaultOrdersAsync(int userId, CheckoutRequest checkoutRequest);
        Task CheckProductAvailability(CheckoutOrderModel orderModel);
        Task UpdateUserOrderAsync(int checkoutOrderId);
    }
}
