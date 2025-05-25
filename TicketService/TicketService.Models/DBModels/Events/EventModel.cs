using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketService.Models.DBModels.Events
{
    [Table("events")]
    public class EventModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("event_type_id")]
        public int EventTypeId { get; set; }

        [Column("date_created")]
        public DateTime DateCreated { get; set; }

        [Column("date_updated")]
        public DateTime? DateUpdated { get; set; }
    }
}
