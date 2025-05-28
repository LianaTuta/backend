using TicketService.Models.RequestModels.Event;
using TicketService.Models.ResponseModels;

namespace TicketService.BL.Interface
{
    public interface IEventService
    {
        Task AddEventAsync(EventRequest addEventRequest);
        Task<List<EventsResponseModel>> GetEventListAsync();
        Task EditEventAsync(int id, EventRequest addEventRequest);
        Task DeleteEventAsync(int id);
        Task<EventsResponseModel> GetEventByIdAsync(int id);

    }
}
