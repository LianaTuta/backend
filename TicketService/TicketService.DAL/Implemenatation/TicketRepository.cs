using Dapper.FastCrud;
using Npgsql;
using TicketService.DAL.DBConnection;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.Events;
using TicketService.Models.DBModels.Orders;

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

        public async Task<TicketModel?> GetTicketDetailsByIdAsync(int id)
        {
            return (await _dbConnection.FindAsync<TicketModel>(statement =>
                    statement
                     .WithAlias("ticket")
                     .Include<EventScheduleModel>()
                     .Include<TicketsCategoryModel>()
                     .Include<EventModel>(join => join.InnerJoin().WithAlias("event"))
                     .Where($@"{nameof(TicketModel.Id):of ticket} = @id")
                     .WithParameters(new { id }))).ToList().FirstOrDefault();
        }

        public async Task InsertQrCodeTicketAsync(QrTicketModel qrTicket)
        {
            await _dbConnection.InsertAsync(qrTicket);
        }


        public async Task<QrTicketModel> GetQrCodeByTicketOrderId(int ticketOrderId)
        {
            return (await _dbConnection.FindAsync<QrTicketModel>(statement =>
                   statement
                   .Where($"{nameof(QrTicketModel.TicketOrderId):C} = @ticketOrderId")
                   .WithParameters(new { ticketOrderId }))).ToList().FirstOrDefault();
        }


        public async Task UpdateQrCodeTicketAsync(QrTicketModel qrTicket)
        {
            _ = await _dbConnection.UpdateAsync(qrTicket);
        }

        public async Task<QrTicketModel> GetTicketByCodeAsync(string code)
        {
            return (await _dbConnection.FindAsync<QrTicketModel>(statement =>
                  statement
                  .Where($"{nameof(QrTicketModel.Code):C} = @code")
                  .WithParameters(new { code }))).ToList().FirstOrDefault();
        }


    }
}
