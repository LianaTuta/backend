namespace TicketService.ApiClient.Interface
{
    public interface IPayPalClient
    {
        string? CreatePayment(decimal amount);
    }
}
