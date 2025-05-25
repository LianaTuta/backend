using Dapper.FastCrud;
using Npgsql;
using TicketService.DAL.DBConnection;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.Events;

namespace TicketService.DAL.Implemenatation
{
    public class EventDetailsRepository : BaseRepository, IEventDetailsRepository
    {
        public EventDetailsRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public async Task InsertEventDetailsAsync(EventDetailsModel eventDetails)
        {
            await _dbConnection.InsertAsync(eventDetails);
        }

        public async Task<EventDetailsModel?> GetEventDetailsByEventIdAsync(int eventId)
        {

            return (await _dbConnection.FindAsync<EventDetailsModel>(statement =>
                statement
            .Where($"{nameof(EventDetailsModel.EventId):C} = @EventId")
            .WithParameters(new { EventId = eventId }))).FirstOrDefault();
        }
    }
}
