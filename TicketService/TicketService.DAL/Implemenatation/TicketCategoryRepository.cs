using Dapper.FastCrud;
using Npgsql;
using TicketService.DAL.DBConnection;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.Events;

namespace TicketService.DAL.Implemenatation
{
    public class TicketCategoryRepository : BaseRepository, ITicketCategoryRepository
    {
        public TicketCategoryRepository(NpgsqlConnection connection) : base(connection)
        {
        }

        public async Task DeleteTicketCategoryAsync(int id)
        {
            _ = await _dbConnection.DeleteAsync(new TicketsCategoryModel { Id = id });
        }

        public async Task EditTicketCategoryAsync(TicketsCategoryModel ticketsCategoryModel)
        {
            _ = await _dbConnection.UpdateAsync<TicketsCategoryModel>(ticketsCategoryModel);
        }

        public async Task<List<TicketsCategoryModel>> GetTicketCategoriesAsync()
        {
            return (await _dbConnection.FindAsync<TicketsCategoryModel>()).ToList();
        }

        public async Task<TicketsCategoryModel> GetTicketCategoryByIdAsync(int id)
        {
            return (await _dbConnection.FindAsync<TicketsCategoryModel>(statement =>
                    statement
                    .Where($"{nameof(TicketsCategoryModel.Id):C} = @Id")
                    .WithParameters(new { Id = id }))).FirstOrDefault();
        }

        public async Task InsertTicketCategoryAsync(TicketsCategoryModel ticketsCategory)
        {
            await _dbConnection.InsertAsync<TicketsCategoryModel>(ticketsCategory);
        }
    }
}
