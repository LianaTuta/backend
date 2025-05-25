using Dapper.FastCrud;
using Npgsql;
using TicketService.DAL.DBConnection;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.Events;

namespace TicketService.DAL.Implemenatation
{
    public class EventScheduleRepository : BaseRepository, IEventScheduleRepository
    {
        public EventScheduleRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public async Task InsertEventScheduleAsync(EventScheduleModel eventSchedule)
        {
            await _dbConnection.InsertAsync(eventSchedule);
        }

        public async Task EditEventScheduleAsync(EventScheduleModel eventSchedule)
        {
            _ = await _dbConnection.UpdateAsync(eventSchedule);
        }

        public async Task DeleteEventScheduleByIdAsync(int id)
        {
            _ = await _dbConnection.DeleteAsync(new EventScheduleModel { Id = id });
        }

        public async Task<List<EventScheduleModel>> GetEventSchedulesByEventIdAsync(int eventId)
        {

            return (await _dbConnection.FindAsync<EventScheduleModel>(statement =>
                    statement
                    .Where($"{nameof(EventScheduleModel.EventId):C} = @EventId")
                    .WithParameters(new { EventId = eventId }))).ToList();
        }

        public async Task<EventScheduleModel> GetEventScheduleByIdAsync(int id)
        {

            return (await _dbConnection.FindAsync<EventScheduleModel>(statement =>
                    statement
                    .Where($"{nameof(EventScheduleModel.Id):C} = @Id")
                    .WithParameters(new { Id = id }))).FirstOrDefault();
        }


    }
}
