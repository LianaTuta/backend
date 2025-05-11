using System.Data;
using Dapper;
using RepoDb;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.Events;

namespace TicketService.DAL.Implemenatation
{
    public class EventRepository : IEventRepository
    {
        private readonly IDbConnection _dbConnection;

        public EventRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
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
            return (await _dbConnection.QueryAllAsync<EventModel>()).ToList();
        }

        public async Task<EventModel?> GetEventByIdAsync(int id)
        {

            return (await _dbConnection.QueryAsync<EventModel>(u => u.Id == id)).FirstOrDefault();
        }
    }
}
