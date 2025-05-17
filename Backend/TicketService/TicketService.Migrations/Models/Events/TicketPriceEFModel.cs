using TicketService.Migrations.Models.User;

namespace TicketService.Migrations.Models.Events
{
    public class TicketPriceEFModel
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int TicketId { get; set; }
        public required TicketEFModel Ticket { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
