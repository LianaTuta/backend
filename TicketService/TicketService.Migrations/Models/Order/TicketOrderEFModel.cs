using System.ComponentModel.DataAnnotations.Schema;
using TicketService.Migrations.Models.Events;

namespace TicketService.Migrations.Models.Order
{
    public class TicketOrderEFModel
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("checkout_order_id")]
        public int CheckoutOrderId { get; set; }
        public required CheckoutOrderEFModel CheckoutOrder { get; set; }

        [Column("ticket_id")]
        public int TicketId { get; set; }
        public required TicketEFModel Ticket { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        public DateTime? EndDate { get; set; }
    }
}
