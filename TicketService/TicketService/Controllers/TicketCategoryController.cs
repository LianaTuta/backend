using Microsoft.AspNetCore.Mvc;
using TicketService.BL.Interface;
using TicketService.Models.DBModels.Events;
using TicketService.Models.RequestModels.Event;

namespace TicketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketCategoryController : ControllerBase
    {
        private readonly ITicketCategoryService _ticketCategoryService;

        public TicketCategoryController(ITicketCategoryService ticketCategoryService)
        {
            _ticketCategoryService = ticketCategoryService;
        }

        [HttpPost()]
        public async Task AddEventAsync(AddNameRequestModel addTicketCategoryRequest)
        {
            await _ticketCategoryService.AddTicketCategoryAsync(addTicketCategoryRequest);
        }

        [HttpGet()]
        public async Task<List<TicketsCategoryModel>> GetEventsListAsync()
        {
            return await _ticketCategoryService.GetTicketCategoriesAsync();
        }

        [HttpPut("{id}")]
        public async Task EditEventAsync(int id, AddNameRequestModel editTicketCategoryRequest)
        {
            await _ticketCategoryService.EditTicketCategoryAsync(id, editTicketCategoryRequest);
        }

        [HttpDelete("{id}")]
        public async Task DeleteEventAsync(int id)
        {
            await _ticketCategoryService.DeleteTicketCategoryAsync(id);
        }
    }
}
