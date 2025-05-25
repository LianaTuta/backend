using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketService.Models.DBModels.Payments
{
    [Table("user_ticket_order_payment")]
    public class UserTicketOrderPayment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("ticket_order_id")]
        public int TickerOrderId { get; set; }

        [Column("user_payment_id")]
        public int UserPaymentId { get; set; }

        [Column("amount")]
        public double Amount { get; set; }

        [Column("date_created")]
        public DateTime DateCreated { get; set; }

        [Column("date_updated")]
        public DateTime? DateUpdated { get; set; }
    }
}
