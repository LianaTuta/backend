using System.Text.Json;
using TicketService.BL.Interface;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.Orders;
using TicketService.Models.Enum;
using TicketService.Models.RequestModels.Order;

namespace TicketService.BL.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }



        public Task CheckProductAvailability(CheckoutOrderModel orderModel)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertDefaultOrdersAsync(int userId, CheckoutRequest checkoutRequest)
        {
            int checkoutOrderId = await SaveCheckoutOrderAsync(userId, checkoutRequest);
            foreach (OrderTicketsModel ticketOrder in checkoutRequest.OrderTickets)
            {
                TicketOrderModel ticket = new()
                {
                    TicketId = ticketOrder.Id,
                    StartDate = DateTime.UtcNow,
                    CheckoutOrderId = checkoutOrderId,
                };
                await _orderRepository.InsertTicketOrderAsync(ticket);
            }
            return checkoutOrderId;
        }


        public async Task UpdateUserOrderAsync(int checkoutOrderId)
        {
            await _orderRepository.UpdateCheckoutOrderAsync(checkoutOrderId, (int)OrderStep.Order);
        }


        #region private 

        private async Task<int> SaveCheckoutOrderAsync(int userId, CheckoutRequest orderModel)
        {


            CheckoutOrderModel order = new()
            {
                UserId = userId,
                Step = (int)OrderStep.Initial,
                DateCreated = DateTime.UtcNow,
                Order = JsonSerializer.Serialize(orderModel),
            };
            return await _orderRepository.InserCheckoutOrderAsync(order);
        }


        #endregion
    }
}

