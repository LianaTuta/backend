using System.ComponentModel.DataAnnotations.Schema;

namespace TicketService.Models.DBModels.Events
{
    [Table("TicketPrice")]
    public class TicketPriceModel
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int TicketId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
