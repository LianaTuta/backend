using System.Data;
using Dapper;
using Microsoft.Extensions.Logging;
using RepoDb;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.Events;

namespace TicketService.DAL.Implemenatation
{
    public class EventRepository : IEventRepository
    {
        private readonly IDbConnection _dbConnection;
        private readonly ILogger<EventRepository> _logger;

        public EventRepository(IDbConnection dbConnection, ILogger<EventRepository> logger)
        {
            _dbConnection = dbConnection;
            _logger = logger;
        }

        public async Task<int> InsertEventAsync(EventModel eventModel)
        {
            int id = await _dbConnection.InsertAsync<EventModel, int>(eventModel);
            return id;
        }

        public async Task EditEventAsync(EventModel eventModel)
        {
            _ = await _dbConnection.UpdateAsync(eventModel);
        }

        public async Task DeleteEventAsync(int id)
        {
            _ = await _dbConnection.DeleteAsync<EventModel>(id);
        }

        public async Task<List<EventModel>> GetEventsAsync()
        {

            _logger.LogInformation($"Using DB connection string: {_dbConnection.ConnectionString}");
            return (await _dbConnection.QueryAllAsync<EventModel>()).ToList();
        }

        public async Task<EventModel?> GetEventByIdAsync(int id)
        {

            return (await _dbConnection.QueryAsync<EventModel>(u => u.Id == id)).FirstOrDefault();
        }
    }
}
