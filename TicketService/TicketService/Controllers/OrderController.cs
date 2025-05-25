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
        public OrderController(IUserAcccountRepository userAcccountRepository,
            ICheckoutService checkoutService,
            IQRTicketService qRTicketService) : base(userAcccountRepository)
        {
            _checkoutService = checkoutService;
            _qRTicketService = qRTicketService;
        }

        [HttpPost()]
        [Authorize]
        public async Task<OrderResponseModel> PlaceOrderAsync(CheckoutRequest checkoutRequest)
        {
            return await _checkoutService.ProcessOrderAsync(await GetUserIdAsync(), checkoutRequest);
        }

        [HttpPost("cancel-order")]
        public async Task CancelOrderAsync(CheckoutRequest checkoutRequest)
        {
            await _checkoutService.CancelOrderAsync(2, checkoutRequest);
        }


        [HttpPost("ticket-order")]
        public async Task TickerOrderAsync(CheckoutRequest checkoutRequest)
        {
            await _qRTicketService.GenerateTicketAsync(1, 25);
        }


    }
}
