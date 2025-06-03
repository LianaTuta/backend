using System.Data;
using Dapper.FastCrud;
using Npgsql;

namespace TicketService.DAL.DBConnection
{
    public abstract class BaseRepository : IDisposable
    {
        protected BaseRepository(NpgsqlConnection connection)
        {
            _dbConnection = connection ?? throw new ArgumentNullException(nameof(connection));
            OrmConfiguration.DefaultDialect = SqlDialect.PostgreSql;
            if (_dbConnection.State != ConnectionState.Open)
            {
                _dbConnection.Open();
            }

        }

        protected NpgsqlConnection _dbConnection { get; }

        public void Dispose()
        {
            try
            {
                if (_dbConnection?.State == ConnectionState.Open)
                {
                    _dbConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Dispose] Error closing connection: {ex.Message}");
            }

        }
    }
}
