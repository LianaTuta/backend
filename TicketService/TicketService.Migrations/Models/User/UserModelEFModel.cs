using System.ComponentModel.DataAnnotations.Schema;

namespace TicketService.Migrations.Models.User
{
    public class UserModelEF
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("email")]
        public required string Email { get; set; }

        [Column("password")]
        public required string Password { get; set; }

        [Column("role_id")]
        public int RoleId { get; set; }
        public required UserRolesModelEF UserRole { get; set; }

        [Column("first_name")]
        public required string FirstName { get; set; }

        [Column("middle_name")]
        public string? MiddleName { get; set; }

        [Column("last_name")]
        public required string LastName { get; set; }

        [Column("email_confirmed")]
        public bool EmailConfirmed { get; set; }

        [Column("birth_date")]
        public DateTime BirthDate { get; set; }

        [Column("date_created")]
        public DateTime DateCreated { get; set; }

        [Column("date_updated")]
        public DateTime? DateUpdated { get; set; }

    }
}
