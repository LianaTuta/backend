using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketService.Models.DBModels.Orders;

namespace TicketService.DAL.Interface
{
    public interface IOrderRepository
    {
        Task InserOrderAsync(OrderModel order);
    }
}
