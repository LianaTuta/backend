using TicketService.Models.DBModels;
using TicketService.Models.RequestModels.Event;

namespace TicketService.BL.Interface
{
    public interface IEventService
    {
        Task AddEventAsync(AddEventRequest addEventRequest);
        Task<List<EventModel>> GetEventListAsync();
        Task EditEventAsync(int id, AddEventRequest addEventRequest);
        Task DeleteAsync(int id);

    }
}
