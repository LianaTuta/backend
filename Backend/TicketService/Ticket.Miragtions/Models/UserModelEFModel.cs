namespace TicketService.Migrations.Models
{
    public class UserModelEF
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public int RoleId { get; set; }
        public required UserRolesModelEF UserRole { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public bool EmailConfirmed { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

    }
}
