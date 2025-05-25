using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketService.Models.DBModels.Payments
{
    [Table("payment")]
    public class PaymentModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("status")]
        public int Status { get; set; }

        [Column("amount")]
        public double Amount { get; set; }

        [Column("checkout_order_id")]
        [ForeignKey("CheckoutOrder")]
        public int CheckoutOrderId { get; set; }
        public CheckoutOrderModel? CheckoutOrder { get; set; }

        [Column("payment_id")]
        public required string PaymentKey { get; set; }

        [Column("return_url")]
        public required string ReturnUrl { get; set; }
        [Column("request")]
        public required string Request { get; set; }
        [Column("response")]
        public required string Response { get; set; }

        [Column("date_created")]
        public DateTime DateCreated { get; set; }

        [Column("date_updated")]
        public DateTime? DateUpdated { get; set; }
    }
}
