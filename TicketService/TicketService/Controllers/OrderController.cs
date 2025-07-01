using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketService.BL.Interface;
using TicketService.DAL.Interface;
using TicketService.Models.RequestModels.Order;
using TicketService.Models.ResponseModels;

namespace TicketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController
    {
        private readonly ICheckoutService _checkoutService;
        private readonly IQRTicketService _qRTicketService;
        private readonly IOrderService _orderService;
        public OrderController(IUserAcccountRepository userAcccountRepository,
            ICheckoutService checkoutService,
            IQRTicketService qRTicketService,
            IOrderService orderService) : base(userAcccountRepository)
        {
            _checkoutService = checkoutService;
            _qRTicketService = qRTicketService;
            _orderService = orderService;
        }

        [HttpPost("place-order")]
        [Authorize]
        public async Task<OrderResponseModel> PlaceOrderAsync(CheckoutRequest checkoutRequest)
        {
            return await _checkoutService.ProcessOrderAsync(await GetUserIdAsync(), checkoutRequest);
        }

        [HttpPost("cancel-order/{checkoutOrderId}")]
        [Authorize]
        public async Task CancelOrderAsync(int checkoutOrderId)
        {
            await _checkoutService.CancelOrderAsync(await GetUserIdAsync(), checkoutOrderId);
        }

        [HttpPost("cancel-order-expired")]
        [Authorize(AuthenticationSchemes = "GoogleOIDC")]
        public async Task CancelExpiredOrders()
        {
            await _checkoutService.CancelExpiredOrdersAsync();
        }

        [HttpGet("is-valid-ticket/{ticketId}")]
        public async Task<ValidTicketModel> IsValidTicket(int ticketId)
        {
            return await _checkoutService.IsValidTicket(ticketId);
        }


        [HttpGet()]
        [Authorize]
        public async Task<List<CheckoutOrderDetailsResponseModel>> RetriveOrdersAsync()
        {
            return await _orderService.GetOrdersAsync(await GetUserIdAsync());
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<CheckoutOrderDetailsResponseModel> RetriveOrderDetailsAsync(int id)
        {
            return await _orderService.GetChekoutOrderDetailsAsync(await GetUserIdAsync(), id);
        }



    }
}
