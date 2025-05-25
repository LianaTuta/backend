using System.ComponentModel.DataAnnotations.Schema;

namespace TicketService.Migrations.Models.User
{
    public class UserRolesModelEF
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public required string Name { get; set; }
    }
}
