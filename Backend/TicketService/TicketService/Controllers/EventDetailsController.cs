using Microsoft.AspNetCore.Mvc;
using TicketService.BL.Interface;
using TicketService.Models.DBModels.Events;
using TicketService.Models.RequestModels.Event;

namespace TicketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventDetailsController : ControllerBase
    {
        private readonly IEventDetailsService _eventDetailsService;
        public EventDetailsController(IEventDetailsService eventDetailsService)
        {
            _eventDetailsService = eventDetailsService;
        }

        [HttpPost("event-details")]
        public async Task AddEventDetails(EventDetailsRequest addEventRequest)
        {
            await _eventDetailsService.AddEventDetailsAsync(addEventRequest);
        }

        [HttpGet("event-details/{eventId}")]
        public async Task<EventDetailsModel> GetEventDetailsAsync(int eventId)
        {
            return await _eventDetailsService.GetEventDetailAsync(eventId);
        }
    }
}
