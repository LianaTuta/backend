using System.Data;
using RepoDb;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.Events;

namespace TicketService.DAL.Implemenatation
{
    public class EventTypeRepository : IEventTypeRepository
    {
        private readonly IDbConnection _dbConnection;

        public EventTypeRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task InsertEventTypeAsync(EventTypeModel eventType)
        {
            _ = await _dbConnection.InsertAsync(eventType);
        }

        public async Task EditEventTypeAsync(EventTypeModel eventType)
        {
            _ = await _dbConnection.UpdateAsync(eventType);
        }

        public async Task DeleteEventTypeByIdAsync(int id)
        {
            _ = await _dbConnection.DeleteAsync<EventTypeModel>(id);
        }

        public async Task<List<EventTypeModel>> GetEventTypesAsync()
        {
            return (await _dbConnection.QueryAllAsync<EventTypeModel>()).ToList();
        }

        public async Task<EventTypeModel> GetEventTypeByIdAsync(int id)
        {
            return (await _dbConnection.QueryAsync<EventTypeModel>(u => u.Id == id)).ToList().FirstOrDefault();
        }
    }
}
