using TicketService.Models.DBModels.Events;
using TicketService.Models.RequestModels.Event;

namespace TicketService.BL.Interface
{
    public interface ITicketService
    {
        Task AddTicketAsync(TicketRequestModel ticket);
        Task EditTicketAsync(int id, TicketRequestModel ticket);
        Task DeleteTicketAsync(int id);
        Task<List<TicketModel>> GetTicketsByEventScheduleIdAsync(int eventScheduleId);
    }
}
