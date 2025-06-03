using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketService.BL.Interface;
using TicketService.Models.DBModels.Events;
using TicketService.Models.Exceptions;
using TicketService.Models.RequestModels;
using TicketService.Models.RequestModels.Event;
using TicketService.Models.ResponseModels;

namespace TicketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {

        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost()]
        public async Task AddTicketAsync(TicketRequestModel addTicketRequestModel)
        {
            await _ticketService.AddTicketAsync(addTicketRequestModel);
        }

        [HttpGet("{eventScheduleId}")]
        public async Task<List<TicketModel>> GetTicketAsync(int eventScheduleId)
        {
            return await _ticketService.GetTicketsByEventScheduleIdAsync(eventScheduleId);
        }



        [HttpPut("{id}")]
        public async Task EditTicketAsync(int id, TicketRequestModel editEventRequest)
        {
            await _ticketService.EditTicketAsync(id, editEventRequest);
        }

        [HttpDelete("{id}")]
        public async Task DeleteTicketAsync(int id)
        {
            await _ticketService.DeleteTicketAsync(id);
        }

        [HttpGet("validate-ticket/{code}")]
        [Authorize(Roles = "Manager")]
        public async Task<ValidateTicketResponseModel> GetTicketDataAsync(string code)
        {
            return await _ticketService.GetTicketDataAsync(code);
        }

        [HttpPost("validate-ticket")]
        [Authorize(Roles = "Manager")]
        public async Task ValidateTicketAsync(ValidateTicketRequest validateTicketResponseModel)
        {
            await _ticketService.ValidateTicketAsync(validateTicketResponseModel);
        }

        [HttpGet("download-ticket/{orderId}")]
        [Authorize]
        public async Task<IActionResult> DownloadTicket(int orderId)
        {
            try
            {
                (MemoryStream stream, string contentType, string fileName) = await _ticketService.DownloadTicketAsync(orderId);
                return File(stream, contentType, fileName);
            }
            catch (CustomException ex)
            {
                return StatusCode((int)ex.StatusCode, new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal error: " + ex.Message });
            }
        }
    }
}
