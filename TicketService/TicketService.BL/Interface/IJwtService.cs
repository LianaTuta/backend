namespace TicketService.BL.Interface
{
    public interface IJwtService
    {
        public string GenerateJwtToken(int id, string role);
    }
}
