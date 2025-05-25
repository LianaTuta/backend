using TicketService.Models.DBModels.Payments;

namespace TicketService.DAL.Interface
{
    public interface IUserPaymentRepository
    {
        Task<int> InsertPaymentAsync(UserPaymentModel payment);
        Task UpdateUserPaymentStatusAsync(int id, int status);
        Task<UserPaymentModel> GetUserPaymentbyPaymentIdAsync(string paymentId);
        Task InsertUserTicketOrderPaymentsAsync(UserTicketOrderPayment payment);
    }
}
