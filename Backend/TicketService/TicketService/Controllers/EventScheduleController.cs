using Microsoft.AspNetCore.Mvc;
using TicketService.BL.Interface;
using TicketService.Models.DBModels.Events;
using TicketService.Models.RequestModels.Event;

namespace TicketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventScheduleController : ControllerBase
    {
        private readonly IEventScheduleService _eventScheduleService;
        public EventScheduleController(IEventScheduleService eventScheduleService)
        {
            _eventScheduleService = eventScheduleService;
        }
        [HttpPost("event-schedule")]
        public async Task AddEventSchedule(EventScheduleRequest addEventRequest)
        {
            await _eventScheduleService.AddEventScheduleAsync(addEventRequest);
        }

        [HttpPut("event-schedule/{id}")]
        public async Task EditEventScheduleAsync(int id, EventScheduleRequest addEventRequest)
        {
            await _eventScheduleService.EditEventScheduleAsync(id, addEventRequest);
        }

        [HttpDelete("event-schedule/{id}")]
        public async Task DeleteEventScheduleAsync(int id)
        {
            await _eventScheduleService.DeleteEventScheduleAsync(id);
        }

        [HttpGet("event-schedule/{eventId}")]
        public async Task<List<EventScheduleModel>> GetEventScheduleByEventIdAsync(int eventId)
        {
            return await _eventScheduleService.GetEventSchedulesByEventIdAsync(eventId);
        }

    }
}
