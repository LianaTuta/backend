using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TicketService.Models.DBModels.Orders;

namespace TicketService.Models.DBModels.Payments
{
    [Table("ticket_order_payment")]
    public class TicketOrderPaymentModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("ticket_order_id")]
        [ForeignKey("TicketOrder")]
        public int TickerOrderId { get; set; }

        [Column("payment_id")]
        [ForeignKey("UserPayment")]
        public int PaymentId { get; set; }

        [Column("amount")]
        public double Amount { get; set; }

        [Column("date_created")]
        public DateTime DateCreated { get; set; }

        [Column("date_updated")]
        public DateTime? DateUpdated { get; set; }

        public TicketOrderModel? TicketOrder { get; set; }
        public PaymentModel? UserPayment { get; set; }

    }
}
