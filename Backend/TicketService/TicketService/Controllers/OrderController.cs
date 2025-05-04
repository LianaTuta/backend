using Microsoft.AspNetCore.Mvc;
using TicketService.BL.Interface;
using TicketService.Models.RequestModels.Order;

namespace TicketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost()]
        public async Task OrderAsync(OrderRequest addEventRequest)
        {
            await _orderService.SaveOrderAsync(addEventRequest);
        }
    }
}
