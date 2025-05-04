using TicketService.Models.DBModels;
using TicketService.Models.RequestModels.Order;

namespace TicketService.BL.Interface
{
    public interface IOrderService
    {
        Task SaveOrderAsync(OrderRequest orderModel);
        Task CheckProductAvailability(OrderModel orderModel);
    }
}
