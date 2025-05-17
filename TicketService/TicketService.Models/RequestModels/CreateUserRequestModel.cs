using TicketService.Models.Enum;

namespace TicketService.Models.RequestModels
{
    public class CreateUserRequestModel
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public UserRolesEnum RoleId { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
