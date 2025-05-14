using TicketService.Models.DBModels.Events;

namespace TicketService.DAL.Interface
{
    public interface ITicketRepository
    {
        Task<int> InsertTicketAsync(TicketModel ticket);
        Task InsertTicketPriceAsync(TicketPriceModel ticket);
        Task UpdateTicketPriceAsync(TicketPriceModel ticket);
        Task DeleteTicketPriceByIdAsync(int id);
        Task EditTicketAsync(TicketModel ticket);
        Task DeleteTicketAsync(int id);
        Task<TicketModel> GetTicketByIdAsync(int id);
        Task<TicketPriceModel> GetTicketPriceByTicketIdAsync(int ticketId);
        Task<List<TicketModel>> GetTicketsByEventScheduleIdAsync(int eventScheduleId);
    }
}
