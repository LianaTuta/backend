using TicketService.Migrations.Models.User;

namespace TicketService.Migrations.Models.Order
{
    public class OrderEFModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public required UserModelEF User { get; set; }
        public int TicketId { get; set; }
        public required TicketEFModel Ticket { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
