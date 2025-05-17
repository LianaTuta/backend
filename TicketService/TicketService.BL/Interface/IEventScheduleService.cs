using TicketService.Models.DBModels.Events;
using TicketService.Models.RequestModels.Event;

namespace TicketService.BL.Interface
{
    public interface IEventScheduleService
    {

        Task AddEventScheduleAsync(EventScheduleRequest addEventScheduleRequest);


        Task EditEventScheduleAsync(int id, EventScheduleRequest eventScheduleRequest);


        Task DeleteEventScheduleAsync(int id);

        Task<List<EventScheduleModel>> GetEventSchedulesByEventIdAsync(int eventId);

    }
}
