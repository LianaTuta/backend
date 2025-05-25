using Dapper.FastCrud;
using Npgsql;
using TicketService.DAL.DBConnection;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.Events;

namespace TicketService.DAL.Implemenatation
{
    public class EventTypeRepository : BaseRepository, IEventTypeRepository
    {
        public EventTypeRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public async Task InsertEventTypeAsync(EventTypeModel eventType)
        {
            await _dbConnection.InsertAsync(eventType);
        }

        public async Task EditEventTypeAsync(EventTypeModel eventType)
        {
            _ = await _dbConnection.UpdateAsync(eventType);
        }

        public async Task DeleteEventTypeByIdAsync(int id)
        {
            _ = await _dbConnection.DeleteAsync(new EventTypeModel { Id = id });
        }

        public async Task<List<EventTypeModel>> GetEventTypesAsync()
        {
            return (await _dbConnection.FindAsync<EventTypeModel>()).ToList();
        }

        public async Task<EventTypeModel> GetEventTypeByIdAsync(int id)
        {
            return (await _dbConnection.FindAsync<EventTypeModel>(statement =>
                        statement
                    .Where($"{nameof(EventTypeModel.Id):C} = @Id")
                    .WithParameters(new { Id = id }))).FirstOrDefault();
        }
    }
}
