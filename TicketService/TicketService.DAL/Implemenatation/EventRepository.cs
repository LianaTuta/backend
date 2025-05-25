using Dapper.FastCrud;
using Npgsql;
using TicketService.DAL.DBConnection;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.Events;

namespace TicketService.DAL.Implemenatation
{
    public class EventRepository : BaseRepository, IEventRepository
    {
        public EventRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public async Task<int> InsertEventAsync(EventModel eventModel)
        {
            await _dbConnection.InsertAsync<EventModel>(eventModel);
            return eventModel.Id;
        }

        public async Task EditEventAsync(EventModel eventModel)
        {
            _ = await _dbConnection.UpdateAsync(eventModel);
        }

        public async Task DeleteEventAsync(int id)
        {
            _ = await _dbConnection.DeleteAsync(new EventModel { Id = id });
        }

        public async Task<List<EventModel>> GetEventsAsync()
        {
            return (await _dbConnection.FindAsync<EventModel>()).ToList();
        }

        public async Task<EventModel?> GetEventByIdAsync(int id)
        {

            return (await _dbConnection.FindAsync<EventModel>(statement =>
                statement
                .Where($"{nameof(EventModel.Id):C} = @id")
                .WithParameters(new { id }))).FirstOrDefault();

        }
    }
}
