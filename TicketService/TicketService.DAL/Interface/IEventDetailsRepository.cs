using TicketService.Models.DBModels.Events;

namespace TicketService.DAL.Interface
{
    public interface IEventDetailsRepository
    {
        Task InsertEventDetailsAsync(EventDetailsModel eventDetails);
        Task<EventDetailsModel?> GetEventDetailsByEventIdAsync(int eventId);
    }
}
