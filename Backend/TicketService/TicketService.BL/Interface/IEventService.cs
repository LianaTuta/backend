using TicketService.Models.DBModels;
using TicketService.Models.RequestModels.Event;
using TicketService.Models.ResponseModels;

namespace TicketService.BL.Interface
{
    public interface IEventService
    {
        Task AddEventAsync(AddEventRequest addEventRequest);
        Task<List<EventsResponseModel>> GetEventListAsync();
        Task EditEventAsync(int id, AddEventRequest addEventRequest);
        Task DeleteAsync(int id);
        Task AddEventDetailsAsync(int id, AddEventDetailsRequest addEventDetailsRequest);
        Task<EventDetailsModel> GetEventDetailAsync(int id);
    }
}
