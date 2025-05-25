using System.ComponentModel.DataAnnotations.Schema;

namespace TicketService.Migrations.Models.Events
{
    public class TicketCategoryEFModel
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public required string Name { get; set; }

        [Column("date_created")]
        public DateTime DateCreated { get; set; }

        [Column("date_updated")]
        public DateTime? DateUpdated { get; set; }
    }
}
