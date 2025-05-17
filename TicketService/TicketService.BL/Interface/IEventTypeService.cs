using TicketService.Models.DBModels.Events;
using TicketService.Models.RequestModels.Event;

namespace TicketService.BL.Interface
{
    public interface IEventTypeService
    {
        Task AddEventTypeAsync(AddNameRequestModel eventTypeRequestModel);
        Task EditEventTypeAsync(int id, AddNameRequestModel eventTypeRequestModel);
        Task DeleteEventTypeAsync(int id);
        Task<List<EventTypeModel>> GetEventTypesAsync();
    }
}
