using TicketService.Models.DBModels.Events;

namespace TicketService.DAL.Interface
{
    public interface IEventTypeRepository
    {
        Task InsertEventTypeAsync(EventTypeModel eventType);
        Task EditEventTypeAsync(EventTypeModel eventType);
        Task DeleteEventTypeByIdAsync(int id);
        Task<List<EventTypeModel>> GetEventTypesAsync();
        Task<EventTypeModel> GetEventTypeByIdAsync(int id);
    }
}
