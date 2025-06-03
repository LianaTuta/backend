using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketService.Models.DBModels.Orders
{
    [Table("qr_ticket")]
    public class QrTicketModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("status")]
        public int Status { get; set; }

        [Column("code")]
        public required string Code { get; set; }

        [Column("ticket_order_id")]
        [ForeignKey("TicketOrder")]
        public int TicketOrderId { get; set; }
        public TicketOrderModel? TicketOrder { get; set; }

        [Column("date_created")]
        public DateTime DateCreated { get; set; }

        [Column("date_updated")]
        public DateTime? DateUpdated { get; set; }
    }
}
