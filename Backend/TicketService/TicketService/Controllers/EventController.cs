using Microsoft.AspNetCore.Mvc;
using TicketService.BL.Interface;
using TicketService.Models.DBModels;
using TicketService.Models.RequestModels.Event;

namespace TicketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpPost()]
        public async Task AddEventAsync(AddEventRequest addEventRequest)
        {
            await _eventService.AddEventAsync(addEventRequest);
        }

        [HttpGet()]
        public async Task<List<EventModel>> GetEventsListAsync()
        {
            return await _eventService.GetEventListAsync();
        }

        [HttpPut("{id}")]
        public async Task EditEventAsync(int id, AddEventRequest addEventRequest)
        {
            await _eventService.EditEventAsync(id, addEventRequest);
        }

        [HttpDelete("{id}")]
        public async Task DeleteEventAsync(int id)
        {
            await _eventService.DeleteAsync(id);
        }
    }
}
