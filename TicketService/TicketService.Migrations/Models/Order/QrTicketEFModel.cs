using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketService.Migrations.Models.Order
{

    [Table("qr_ticket")]
    public class QrTicketEFModel
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
        public TicketOrderEFModel? TicketOrder { get; set; }

        [Column("date_created")]
        public DateTime DateCreated { get; set; }

        [Column("date_updated")]
        public DateTime? DateUpdated { get; set; }
    }

}
