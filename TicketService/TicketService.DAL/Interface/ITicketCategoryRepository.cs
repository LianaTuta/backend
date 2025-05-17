using TicketService.Models.DBModels.Events;

namespace TicketService.DAL.Interface
{
    public interface ITicketCategoryRepository
    {
        Task DeleteTicketCategoryAsync(int id);
        Task EditTicketCategoryAsync(TicketsCategoryModel ticketsCategoryModel);
        Task<List<TicketsCategoryModel>> GetTicketCategoriesAsync();
        Task<TicketsCategoryModel> GetTicketCategoryByIdAsync(int id);
        Task InsertTicketCategoryAsync(TicketsCategoryModel ticketsCategory);
    }
}
