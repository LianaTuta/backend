using TicketService.Models.DBModels.Events;
using TicketService.Models.RequestModels.Event;

namespace TicketService.BL.Interface
{
    public interface IEventDetailsService
    {
        Task AddEventDetailsAsync(EventDetailsRequest addEventDetailsRequest);
        Task<EventDetailsModel> GetEventDetailAsync(int id);
    }
}
