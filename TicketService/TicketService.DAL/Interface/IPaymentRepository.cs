using TicketService.Models.DBModels.Payments;

namespace TicketService.DAL.Interface
{
    public interface IPaymentRepository
    {
        Task<int> InsertPaymentAsync(PaymentModel payment);
        Task UpdateUserPaymentStatusAsync(int id, int status, string? paymentId = null);
        Task<PaymentModel> GetUserPaymentbyPaymentKeyAsync(string paymentKey);
        Task<PaymentModel> GetPaymentByCheckoutOrderIdAsync(int checkoutOrderId);
        Task InsertUserTicketOrderPaymentsAsync(TicketOrderPaymentModel payment);
        Task<TicketOrderPaymentModel> GetTicketOrderPaymentAsync(int ticketOrderId);

    }
}
