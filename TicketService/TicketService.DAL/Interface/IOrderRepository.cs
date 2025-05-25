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
    }
}
