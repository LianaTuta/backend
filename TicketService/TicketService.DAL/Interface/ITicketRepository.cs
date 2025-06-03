using TicketService.Models.DBModels.Events;
using TicketService.Models.DBModels.Orders;

namespace TicketService.DAL.Interface
{
    public interface ITicketRepository
    {
        Task<int> InsertTicketAsync(TicketModel ticket);
        Task EditTicketAsync(TicketModel ticket);
        Task DeleteTicketAsync(int id);
        Task<TicketModel> GetTicketByIdAsync(int id);
        Task<List<TicketModel>> GetTicketsByEventScheduleIdAsync(int eventScheduleId);
        Task<TicketModel?> GetTicketDetailsByIdAsync(int id);
        Task InsertQrCodeTicketAsync(QrTicketModel qrTicket);
        Task UpdateQrCodeTicketAsync(QrTicketModel qrTicket);
        Task<QrTicketModel> GetQrCodeByTicketOrderId(int ticketOrderId);
        Task<QrTicketModel> GetTicketByCodeAsync(string code);
    }
}
