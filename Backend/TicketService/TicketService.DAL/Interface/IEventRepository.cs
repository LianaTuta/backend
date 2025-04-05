using TicketService.Models.DBModels;

namespace TicketService.DAL.Interface
{
    public interface IEventRepository
    {
        Task InserEventAsync(EventModel eventModel);
        Task EditEventAsync(EventModel eventModel);
        Task DeleteEventAsync(int id);
        Task<List<EventModel>> GetEventsAsync();
        Task<EventModel?> GetEventByIdAsync(int id);
    }
}
