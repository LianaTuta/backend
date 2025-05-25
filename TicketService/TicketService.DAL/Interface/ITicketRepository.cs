using TicketService.Models.DBModels.Events;

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
    }
}
