using System.ComponentModel.DataAnnotations.Schema;

namespace TicketService.Models.DBModels.User
{
    [Table("UserRoles")]
    public class UserRolesModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
