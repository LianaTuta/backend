using Dapper.FastCrud;
using Npgsql;
using NpgsqlTypes;
using TicketService.DAL.DBConnection;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.Payments;

namespace TicketService.DAL.Implemenatation
{
    public class UserPaymentRepository : BaseRepository, IUserPaymentRepository
    {
        public UserPaymentRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public async Task<UserPaymentModel> GetUserPaymentbyPaymentIdAsync(string paymentId)
        {
            return (await _dbConnection.FindAsync<UserPaymentModel>(statement =>
                    statement
                    .Where($"{nameof(UserPaymentModel.PaymentId):C} = @paymentId")
                        .WithParameters(new { paymentId }))).ToList().FirstOrDefault();
        }

        public async Task<int> InsertPaymentAsync(UserPaymentModel payment)
        {

            const string sql = @"
                    INSERT INTO user_payment
                        (user_id, status, payment_id, request, response, date_created, return_url)
                    VALUES
                         (@user_id, @status, @payment_id, @request, @response, @date_created, @return_url)
                    RETURNING id;
                    ";

            await using NpgsqlCommand command = new(sql, _dbConnection);

            _ = command.Parameters.AddWithValue("user_id", payment.UserId);
            _ = command.Parameters.AddWithValue("status", payment.Status);
            _ = command.Parameters.AddWithValue("payment_id", payment.PaymentId);
            _ = command.Parameters.AddWithValue("request", NpgsqlDbType.Jsonb, payment.Request);
            _ = command.Parameters.AddWithValue("response", NpgsqlDbType.Jsonb, payment.Response);
            _ = command.Parameters.AddWithValue("date_created", payment.DateCreated);

            object? result = await command.ExecuteScalarAsync();
            return Convert.ToInt32(result);
        }

        public async Task InsertUserTicketOrderPaymentsAsync(UserTicketOrderPayment payment)
        {
            await _dbConnection.InsertAsync(payment);
        }

        public async Task UpdateUserPaymentStatusAsync(int id, int status)
        {
            const string sql = @"
                        UPDATE user_payment
                        SET status       = @status,
                        date_updated = NOW()
                    WHERE id = @id;";

            await using NpgsqlCommand cmd = new(sql, _dbConnection);
            _ = cmd.Parameters.AddWithValue("status", status);
            _ = cmd.Parameters.AddWithValue("id", id);

            _ = await cmd.ExecuteNonQueryAsync();
        }
    }
}
