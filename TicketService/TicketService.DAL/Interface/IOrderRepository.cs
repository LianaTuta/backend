using TicketService.Models.DBModels.Orders;

namespace TicketService.DAL.Interface
{
    public interface IOrderRepository
    {
        Task<int> InserCheckoutOrderAsync(CheckoutOrderModel order);
        Task InsertTicketOrderAsync(TicketOrderModel ticketOrder);
        Task<List<TicketOrderModel>> GetTicketOrderByCheckoutOrderIdAsync(int checkoutOrderId);
        Task UpdateCheckoutOrderAsync(int checkoutOrderId, int status);
        Task<int> GetCheckoutOrderByPaymentIdAsync(int paymentId);
        Task<CheckoutOrderModel> GetOrdersByCheckoutOrderIdAsync(int userId);
        Task<List<CheckoutOrderModel>> GetOrdersByUserIdAsync(int userId);
        Task<List<CheckoutOrderModel>> GetExpiredOrdersAsync();

        Task UpdateTicketOrderAsync(TicketOrderModel ticketOrder);

        Task<TicketOrderModel> GetTicketOrderByIdAsync(int id);

        Task<List<TicketOrderModel>> GetActiveOrdersAsync(int ticketId);
    }
}
