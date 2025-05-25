using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TicketService.Models.DBModels.Events;

namespace TicketService.Models.DBModels.Orders
{
    [Table("ticket_order")]
    public class TicketOrderModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("checkout_order_id")]
        public int CheckoutOrderId { get; set; }

        [Column("ticket_id")]
        [ForeignKey("Ticket")]
        public int TicketId { get; set; }
        public TicketModel? Ticket { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        public DateTime? EndDate { get; set; }
    }
}
