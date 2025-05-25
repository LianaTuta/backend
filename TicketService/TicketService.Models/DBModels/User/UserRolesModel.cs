using System.ComponentModel.DataAnnotations.Schema;

namespace TicketService.Models.DBModels.User
{
    [Table("user_roles")]
    public class UserRolesModel
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }
    }
}
