using TicketService.Models.DBModels.Events;

namespace TicketService.DAL.Interface
{
    public interface IEventScheduleRepository
    {

        Task InsertEventScheduleAsync(EventScheduleModel eventSchedule);
        Task EditEventScheduleAsync(EventScheduleModel eventSchedule);
        Task DeleteEventScheduleByIdAsync(int id);
        Task<List<EventScheduleModel>> GetEventSchedulesByEventIdAsync(int eventId);
        Task<EventScheduleModel> GetEventScheduleByIdAsync(int id);
    }
}
