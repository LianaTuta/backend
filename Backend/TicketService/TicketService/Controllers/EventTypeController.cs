using Microsoft.AspNetCore.Mvc;
using TicketService.BL.Interface;
using TicketService.Models.DBModels.Events;
using TicketService.Models.RequestModels.Event;

namespace TicketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventTypeController : ControllerBase
    {
        private readonly IEventTypeService _eventTypeService;
        public EventTypeController(IEventTypeService eventTypeService)
        {
            _eventTypeService = eventTypeService;
        }

        [HttpPost("event-type")]
        public async Task AddEventTypeAsync(AddNameRequestModel addEventRequest)
        {
            await _eventTypeService.AddEventTypeAsync(addEventRequest);
        }

        [HttpPut("event-type/{id}")]
        public async Task EditEventTypeAsync(int id, AddNameRequestModel addEventRequest)
        {
            await _eventTypeService.EditEventTypeAsync(id, addEventRequest);
        }

        [HttpDelete("event-type/{id}")]
        public async Task DeleteEventTypeAsync(int id)
        {
            await _eventTypeService.DeleteEventTypeAsync(id);
        }

        [HttpGet("event-type")]
        public async Task<List<EventTypeModel>> GetEventTypesAsync()
        {
            return await _eventTypeService.GetEventTypesAsync();
        }


        [HttpPost("ticket-category")]
        public async Task AddTicketCategory()
        {
            _ = await _eventTypeService.GetEventTypesAsync();
        }

    }
}
