using System.Data;
using RepoDb;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.Events;

namespace TicketService.DAL.Implemenatation
{
    public class EventScheduleRepository : IEventScheduleRepository
    {

        private readonly IDbConnection _dbConnection;

        public EventScheduleRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task InsertEventScheduleAsync(EventScheduleModel eventSchedule)
        {
            _ = await _dbConnection.InsertAsync(eventSchedule);
        }

        public async Task EditEventScheduleAsync(EventScheduleModel eventSchedule)
        {
            _ = await _dbConnection.UpdateAsync(eventSchedule);
        }

        public async Task DeleteEventScheduleByIdAsync(int id)
        {
            _ = await _dbConnection.DeleteAsync<EventScheduleModel>(id);
        }

        public async Task<List<EventScheduleModel>> GetEventSchedulesByEventIdAsync(int eventId)
        {

            return (await _dbConnection.QueryAsync<EventScheduleModel>(u => u.EventId == eventId)).ToList();
        }

        public async Task<EventScheduleModel> GetEventScheduleByIdAsync(int id)
        {

            return (await _dbConnection.QueryAsync<EventScheduleModel>(u => u.Id == id)).ToList().FirstOrDefault();
        }


    }
}
