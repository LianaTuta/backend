using TicketService.Models.DBModels;

namespace TicketService.DAL.Interface
{
    public interface IEventRepository
    {
        Task<int> InserEventAsync(EventModel eventModel);
        Task EditEventAsync(EventModel eventModel);
        Task DeleteEventAsync(int id);
        Task<List<EventModel>> GetEventsAsync();
        Task<EventModel?> GetEventByIdAsync(int id);
        Task InserEventDetailsAsync(EventDetailsModel eventDetails);
        Task<EventDetailsModel?> GetEventDetailsByEventIdAsync(int eventId);
    }
}
