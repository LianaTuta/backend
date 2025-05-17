using TicketService.Models.DBModels.Events;

namespace TicketService.DAL.Interface
{
    public interface IEventRepository
    {
        Task<int> InsertEventAsync(EventModel eventModel);
        Task EditEventAsync(EventModel eventModel);
        Task DeleteEventAsync(int id);
        Task<List<EventModel>> GetEventsAsync();
        Task<EventModel?> GetEventByIdAsync(int id);
    }
}
