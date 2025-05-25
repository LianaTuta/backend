namespace TicketService.Models.Enum
{
    public enum OrderStep
    {
        Initial = 0,
        Payment,
        Order,
        QrCode,
        Completed
    }
}
