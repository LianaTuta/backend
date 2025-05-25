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
        }

        protected NpgsqlConnection _dbConnection { get; }

        public void Dispose()
        {
            _dbConnection.Dispose();
        }
    }
}
