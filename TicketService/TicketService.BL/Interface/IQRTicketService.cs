namespace TicketService.BL.Interface
{
    public interface IQRTicketService
    {
        Task GenerateTicketAsync(int userId, int checkoutOrderId);
        Task UpdateTicketAsync(int userId, int checkoutOrderId);
    }
}
