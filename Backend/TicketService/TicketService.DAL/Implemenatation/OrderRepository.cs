using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoDb;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels;

namespace TicketService.DAL.Implemenatation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbConnection _dbConnection;
        public OrderRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task InserOrderAsync(OrderModel order)
        {
            await _dbConnection.InsertAsync(order);
        }
    }
}
