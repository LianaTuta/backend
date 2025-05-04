using TicketService.BL.Interface;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels;
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



        public Task CheckProductAvailability(OrderModel orderModel)
        {
            throw new NotImplementedException();
        }

        public async Task SaveOrderAsync(int userId, OrderRequest orderModel)
        {
            OrderModel order = new()
            {
                EventId = orderModel.EventId,

                UserId = userId,
                StartDate = orderModel.StartDate,
            };
            await _orderRepository.InserOrderAsync(order);
        }

        public Task SaveOrderAsync(OrderRequest orderModel)
        {
            throw new NotImplementedException();
        }
    }
}

