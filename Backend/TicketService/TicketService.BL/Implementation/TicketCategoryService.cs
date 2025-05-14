using TicketService.BL.Interface;
using TicketService.DAL.Interface;
using TicketService.Models.DBModels.Events;
using TicketService.Models.RequestModels.Event;

namespace TicketService.BL.Implementation
{
    public class TicketCategoryService : ITicketCategoryService
    {
        private readonly ITicketCategoryRepository _ticketCategoryRepository;
        private readonly IValidationService _validationService;
        public TicketCategoryService(ITicketCategoryRepository ticketCategoryRepository,
            IValidationService validationService)
        {
            _ticketCategoryRepository = ticketCategoryRepository;
            _validationService = validationService;
        }

        public async Task AddTicketCategoryAsync(AddNameRequestModel ticketsCategory)
        {
            TicketsCategoryModel ticketCategoryModel = new()
            {
                Name = ticketsCategory.Name,
                DateCreated = DateTime.UtcNow,
            };
            await _ticketCategoryRepository.InsertTicketCategoryAsync(ticketCategoryModel);
        }

        public async Task DeleteTicketCategoryAsync(int id)
        {
            await _validationService.CheckTicketCategoryAsync(id);
            await _ticketCategoryRepository.DeleteTicketCategoryAsync(id);
        }

        public async Task EditTicketCategoryAsync(int id, AddNameRequestModel ticketsCategoryModel)
        {
            await _validationService.CheckTicketCategoryAsync(id);
            TicketsCategoryModel currentTicketCategory = await _ticketCategoryRepository.GetTicketCategoryByIdAsync(id);
            currentTicketCategory.DateUpdated = DateTime.UtcNow;
            currentTicketCategory.Name = ticketsCategoryModel.Name;
            await _ticketCategoryRepository.EditTicketCategoryAsync(currentTicketCategory);

        }

        public async Task<List<TicketsCategoryModel>> GetTicketCategoriesAsync()
        {
            return await _ticketCategoryRepository.GetTicketCategoriesAsync();
        }


    }
}
