using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TicketService.Migrations.Models.Order;

namespace TicketService.Migrations.Models.Transactions
{
    public class TicketOrderPaymenrEfModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("ticket_order_id")]
        public int TickerOrderId { get; set; }
        public required TicketOrderEFModel TicketOrder { get; set; }

        [Column("payment_id")]
        public int PaymentId { get; set; }
        public required PaymentsEFModel Payment { get; set; }

        [Column("amount")]
        public double Amount { get; set; }

        [Column("date_created")]
        public DateTime DateCreated { get; set; }

        [Column("date_updated")]
        public DateTime? DateUpdated { get; set; }
    }
}
