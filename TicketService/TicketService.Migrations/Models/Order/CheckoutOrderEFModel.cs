using System.ComponentModel.DataAnnotations.Schema;
using TicketService.Migrations.Models.User;

namespace TicketService.Migrations.Models.Order
{
    public class CheckoutOrderEFModel
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }
        public required UserModelEF UserModel { get; set; }

        [Column("step")]
        public int Step { get; set; }

        [Column("order")]
        public required Dictionary<string, object> Order { get; set; }

        [Column("date_created")]
        public DateTime DateCreated { get; set; }

        [Column("date_updated")]
        public DateTime? DateUpdated { get; set; }

    }
}
