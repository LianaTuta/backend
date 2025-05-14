using System.Data;
using Dapper;
using RepoDb;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.Events;

namespace TicketService.DAL.Implemenatation
{
    public class TicketRepository : ITicketRepository
    {

        private readonly IDbConnection _dbConnection;

        public TicketRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<int> InsertTicketAsync(TicketModel ticket)
        {
            int id = await _dbConnection.InsertAsync<TicketModel, int>(ticket);
            return id;
        }
        public async Task EditTicketAsync(TicketModel ticket)
        {
            _ = await _dbConnection.UpdateAsync(ticket);
        }
        public async Task DeleteTicketAsync(int id)
        {
            _ = await _dbConnection.DeleteAsync<TicketModel>(id);
        }
        public async Task<List<TicketModel>> GetTicketsByEventScheduleIdAsync(int eventScheduleId)
        {

            return (await _dbConnection.QueryAsync<TicketModel>(u => u.EventScheduleId == eventScheduleId)).ToList();
        }

        public async Task<TicketModel> GetTicketByIdAsync(int id)
        {
            return (await _dbConnection.QueryAsync<TicketModel>(u => u.Id == id)).FirstOrDefault();
        }

        public async Task InsertTicketPriceAsync(TicketPriceModel ticket)
        {
            _ = await _dbConnection.InsertAsync(ticket); ;
        }

        public async Task UpdateTicketPriceAsync(TicketPriceModel ticket)
        {
            _ = await _dbConnection.UpdateAsync(ticket);
        }

        public async Task<TicketPriceModel> GetTicketPriceByTicketIdAsync(int ticketId)
        {
            return (await _dbConnection.QueryAsync<TicketPriceModel>(u => u.TicketId == ticketId)).ToList().FirstOrDefault();
        }

        public async Task DeleteTicketPriceByIdAsync(int id)
        {
            _ = await _dbConnection.DeleteAsync<TicketPriceModel>(id);
        }
    }
}
