namespace TicketService.BL.Interface
{
    public interface IValidationService
    {
        Task CheckEventAsync(int id);
        Task CheckEventScheduleAsync(int id);
        Task CheckEventTypeAsync(int id);
        Task CheckTicketCategoryAsync(int id);
        Task CheckTicketAsync(int id);

    }
}
