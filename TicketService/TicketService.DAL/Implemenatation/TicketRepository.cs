using Dapper.FastCrud;
using Npgsql;
using TicketService.DAL.DBConnection;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.Events;

namespace TicketService.DAL.Implemenatation
{
    public class TicketRepository : BaseRepository, ITicketRepository
    {
        public TicketRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public async Task<int> InsertTicketAsync(TicketModel ticket)
        {
            await _dbConnection.InsertAsync<TicketModel>(ticket);
            return ticket.Id;
        }
        public async Task EditTicketAsync(TicketModel ticket)
        {
            _ = await _dbConnection.UpdateAsync(ticket);
        }
        public async Task DeleteTicketAsync(int id)
        {
            _ = await _dbConnection.DeleteAsync(new TicketModel { Id = id });
        }
        public async Task<List<TicketModel>> GetTicketsByEventScheduleIdAsync(int eventScheduleId)
        {

            return (await _dbConnection.FindAsync<TicketModel>(statement =>
                    statement
                    .Where($"{nameof(TicketModel.EventScheduleId):C} = @EventScheduleId")
                    .WithParameters(new { EventScheduleId = eventScheduleId }))).ToList();
        }

        public async Task<TicketModel?> GetTicketByIdAsync(int id)
        {
            return (await _dbConnection.FindAsync<TicketModel>(statement =>
                    statement
                    .Where($"{nameof(TicketModel.Id):C} = @Id")
                    .WithParameters(new { Id = id }))).ToList().FirstOrDefault();
        }


    }
}
