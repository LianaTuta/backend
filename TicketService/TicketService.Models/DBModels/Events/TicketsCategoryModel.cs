using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketService.Models.DBModels.Events
{
    [Table("ticket_category")]
    public class TicketsCategoryModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string? Name { get; set; }
        [Column("date_created")]
        public DateTime DateCreated { get; set; }
        [Column("date_updated")]
        public DateTime? DateUpdated { get; set; }
    }
}
