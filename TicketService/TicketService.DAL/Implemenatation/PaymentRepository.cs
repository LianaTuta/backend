using Dapper.FastCrud;
using Npgsql;
using NpgsqlTypes;
using TicketService.DAL.DBConnection;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.Payments;

namespace TicketService.DAL.Implemenatation
{
    public class PaymentRepository : BaseRepository, IPaymentRepository
    {
        public PaymentRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public async Task<PaymentModel> GetUserPaymentbyPaymentKeyAsync(string paymentKey)
        {
            return (await _dbConnection.FindAsync<PaymentModel>(statement =>
                    statement
                    .Where($"{nameof(PaymentModel.PaymentKey):C} = @paymentKey")
                        .WithParameters(new { paymentKey }))).ToList().FirstOrDefault();
        }

        public async Task<int> InsertPaymentAsync(PaymentModel payment)
        {

            const string sql = @"INSERT INTO payment (user_id, status, payment_id, request, response, date_created, return_url, checkout_order_id, amount)
                    VALUES (@user_id, @status, @payment_id, @request, @response, now(), @return_url, @checkout_order_id, @amount)
                    RETURNING id;";

            await using NpgsqlCommand command = new(sql, _dbConnection);

            _ = command.Parameters.AddWithValue("user_id", payment.UserId);
            _ = command.Parameters.AddWithValue("status", payment.Status);
            _ = command.Parameters.AddWithValue("return_url", payment.ReturnUrl);
            _ = command.Parameters.AddWithValue("payment_id", payment.PaymentKey);
            _ = command.Parameters.AddWithValue("amount", payment.Amount);
            _ = command.Parameters.AddWithValue("checkout_order_id", payment.CheckoutOrderId);
            _ = command.Parameters.AddWithValue("request", NpgsqlDbType.Jsonb, payment.Request);
            _ = command.Parameters.AddWithValue("response", NpgsqlDbType.Jsonb, payment.Response);

            object? result = await command.ExecuteScalarAsync();
            return Convert.ToInt32(result);
        }

        public async Task InsertUserTicketOrderPaymentsAsync(TicketOrderPaymentModel payment)
        {
            await _dbConnection.InsertAsync(payment);
        }

        public async Task UpdateUserPaymentStatusAsync(int id, int status)
        {
            const string sql = @"UPDATE payment
                        SET status  = @status,
                        date_updated = NOW()
                        WHERE id = @id;";

            await using NpgsqlCommand cmd = new(sql, _dbConnection);
            _ = cmd.Parameters.AddWithValue("status", status);
            _ = cmd.Parameters.AddWithValue("id", id);
            _ = await cmd.ExecuteNonQueryAsync();
        }

        public async Task<PaymentModel> GetPaymentByCheckoutOrderIdAsync(int checkoutOrderId)
        {
            return (await _dbConnection.FindAsync<PaymentModel>(statement =>
                  statement
                  .Where($"{nameof(PaymentModel.CheckoutOrderId):C} = @checkoutOrderId")
                      .WithParameters(new { checkoutOrderId }))).ToList().FirstOrDefault();
        }
    }
}
