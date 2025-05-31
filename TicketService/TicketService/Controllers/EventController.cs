using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketService.BL.Interface;
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
        [Authorize(Roles = "Manager")]
        public async Task AddEventAsync(EventRequest addEventRequest)
        {
            await _eventService.AddEventAsync(addEventRequest);
        }

        [HttpGet()]
        public async Task<List<EventsResponseModel>> GetEventsListAsync()
        {
            return await _eventService.GetEventListAsync();
        }


        [HttpGet("{id}")]
        public async Task<EventsResponseModel> GetEventById(int id)
        {
            return await _eventService.GetEventByIdAsync(id);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task EditEventAsync(int id, EventRequest addEventRequest)
        {
            await _eventService.EditEventAsync(id, addEventRequest);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task DeleteEventAsync(int id)
        {
            await _eventService.DeleteEventAsync(id);
        }

    }
}
