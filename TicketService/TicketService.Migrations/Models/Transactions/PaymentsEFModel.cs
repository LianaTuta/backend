﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TicketService.Migrations.Models.Order;
using TicketService.Migrations.Models.User;

namespace TicketService.Migrations.Models.Transactions
{
    public class PaymentsEFModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }
        public required UserModelEF UserModel { get; set; }

        [Column("checkout_order_id")]
        public int CheckoutOrderId { get; set; }
        public required CheckoutOrderEFModel CheckoutOrder { get; set; }

        [Column("status")]
        public int Status { get; set; }

        [Column("return_url")]
        public required string ReturnUrl { get; set; }

        [Column("amount")]
        public required double Amount { get; set; }

        [Column("payment_id")]
        public string? PaymentIntent { get; set; }
        [Column("payment_key")]
        public required string PaymentKey { get; set; }


        [Column("request")]
        public required Dictionary<string, object> Request { get; set; }

        [Column("response")]
        public required Dictionary<string, object>? Response { get; set; }

        [Column("date_created")]
        public DateTime DateCreated { get; set; }

        [Column("date_updated")]
        public DateTime? DateUpdated { get; set; }
    }
}
