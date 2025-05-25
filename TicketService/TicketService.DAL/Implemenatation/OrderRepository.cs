using Dapper.FastCrud;
using Npgsql;
using NpgsqlTypes;
using TicketService.DAL.DBConnection;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.Events;
using TicketService.Models.DBModels.Orders;
using TicketService.Models.DBModels.Payments;

namespace TicketService.DAL.Implemenatation
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public async Task<int> InserCheckoutOrderAsync(CheckoutOrderModel order)
        {

            using NpgsqlCommand command = new(@" INSERT INTO checkout_order (user_id, ""order"", step, date_created)
                                     VALUES (@user_id, @order, @step, @date_created)
                                    RETURNING id;
                                    ", _dbConnection);

            _ = command.Parameters.AddWithValue("user_id", order.UserId);
            _ = command.Parameters.AddWithValue("order", NpgsqlDbType.Jsonb, order.Order);
            _ = command.Parameters.AddWithValue("step", order.Step);
            _ = command.Parameters.AddWithValue("date_created", order.DateCreated);

            object? result = await command.ExecuteScalarAsync();
            return Convert.ToInt32(result);

        }

        public async Task InsertTicketOrderAsync(TicketOrderModel ticketOrder)
        {
            await _dbConnection.InsertAsync(ticketOrder);
        }

        public async Task<List<TicketOrderModel>> GetTicketOrderByCheckoutOrderIdAsync(int checkoutOrderId)
        {
            return (await _dbConnection.FindAsync<TicketOrderModel>(statement =>
                    statement
                    .Include<TicketModel>(join => join.WithAlias("Ticket").InnerJoin())
                    .Where($"{nameof(TicketOrderModel.CheckoutOrderId):C} = @checkoutOrderId")
                    .WithParameters(new { checkoutOrderId }))).ToList();
        }

        public async Task UpdateCheckoutOrderAsync(int checkoutOrderId, int status)
        {

            const string sql = @"
                     UPDATE checkout_order
                     SET step  = @step,
                     date_updated = NOW()
                     WHERE id = @id;";

            await using NpgsqlCommand command = new(sql, _dbConnection);
            _ = command.Parameters.AddWithValue("step", status);
            _ = command.Parameters.AddWithValue("id", checkoutOrderId);
            _ = await command.ExecuteNonQueryAsync();
        }


        public async Task<int> GetCheckoutOrderByPaymentIdAsync(int paymentId)
        {
            return (await _dbConnection.FindAsync<PaymentModel>(statement => statement
                                    .WithAlias("payment")
                                    .Include<CheckoutOrderModel>(join => join.InnerJoin().WithAlias("checkout"))
                                    .Where($@"{nameof(PaymentModel.Id):of payment} = @paymentId")
                                    .WithParameters(new { paymentId }))).ToList().Select(o => o.CheckoutOrder.Id).FirstOrDefault();
        }

    }
}
