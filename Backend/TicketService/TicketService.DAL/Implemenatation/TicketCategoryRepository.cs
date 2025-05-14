using System.Data;
using RepoDb;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.Events;

namespace TicketService.DAL.Implemenatation
{
    public class TicketCategoryRepository : ITicketCategoryRepository
    {
        private readonly IDbConnection _dbConnection;

        public TicketCategoryRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task DeleteTicketCategoryAsync(int id)
        {
            _ = await _dbConnection.DeleteAsync<TicketsCategoryModel>(id);
        }

        public async Task EditTicketCategoryAsync(TicketsCategoryModel ticketsCategoryModel)
        {
            _ = await _dbConnection.UpdateAsync<TicketsCategoryModel>(ticketsCategoryModel);
        }

        public async Task<List<TicketsCategoryModel>> GetTicketCategoriesAsync()
        {
            return (await _dbConnection.QueryAllAsync<TicketsCategoryModel>()).ToList();
        }

        public async Task<TicketsCategoryModel> GetTicketCategoryByIdAsync(int id)
        {
            return (await _dbConnection.QueryAsync<TicketsCategoryModel>(u => u.Id == id)).FirstOrDefault();
        }

        public async Task InsertTicketCategoryAsync(TicketsCategoryModel ticketsCategory)
        {
            _ = await _dbConnection.InsertAsync<TicketsCategoryModel>(ticketsCategory);
        }
    }
}
