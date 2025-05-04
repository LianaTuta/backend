using Microsoft.AspNetCore.Mvc;
using TicketService.BL.Interface;
using TicketService.Models.DBModels;
using TicketService.Models.RequestModels.Event;
using TicketService.Models.ResponseModels;

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
        public async Task<List<EventsResponseModel>> GetEventsListAsync()
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

        [HttpPost("add-event-details/{id}")]
        public async Task AddEventDetails(int id, AddEventDetailsRequest addEventRequest)
        {
            await _eventService.AddEventDetailsAsync(id, addEventRequest);
        }

        [HttpGet("event-details/{id}")]
        public async Task<EventDetailsModel> GetEventDetailsAsync(int id)
        {
            return await _eventService.GetEventDetailAsync(id);
        }
    }
}
