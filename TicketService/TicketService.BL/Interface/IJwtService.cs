namespace TicketService.BL.Interface
{
    public interface IJwtService
    {
        string GenerateJwtToken(string email, string role);
    }
}
