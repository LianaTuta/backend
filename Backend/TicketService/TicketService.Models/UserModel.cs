using System.ComponentModel.DataAnnotations.Schema;
using TicketService.Models.Enum;

namespace TicketService.Models
{
    [Table("Users")]
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRolesEnum RoleId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailConfirmed { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

        
        
    }
}
