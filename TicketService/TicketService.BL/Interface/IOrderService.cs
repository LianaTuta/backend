using TicketService.Models.RequestModels.Order;
using TicketService.Models.ResponseModels;

namespace TicketService.BL.Interface
{
    public interface IOrderService
    {
        Task<int> InsertDefaultOrdersAsync(int userId, CheckoutRequest checkoutRequest);
        Task CheckProductAvailability(CheckoutOrderModel orderModel);
        Task UpdateUserOrderAsync(int checkoutOrderId, int orderStep);
        Task<List<CheckoutOrderDetailsResponseModel>> GetOrdersAsync(int userId);
        Task<CheckoutOrderDetailsResponseModel?> GetChekoutOrderDetailsAsync(int userId, int checkoutOrderId);
        Task CancelCheckoutOrderAsync(int checkoutOrderId);


    }
}
