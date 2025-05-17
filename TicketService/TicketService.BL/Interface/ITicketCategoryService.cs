using TicketService.Models.DBModels.Events;
using TicketService.Models.RequestModels.Event;

namespace TicketService.BL.Interface
{
    public interface ITicketCategoryService
    {

        Task DeleteTicketCategoryAsync(int id);
        Task EditTicketCategoryAsync(int id, AddNameRequestModel ticketsCategoryModel);
        Task<List<TicketsCategoryModel>> GetTicketCategoriesAsync();
        Task AddTicketCategoryAsync(AddNameRequestModel ticketsCategory);
    }
}
