﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketService.Models.DBModels.Events
{
    [Table("ticket")]
    public class TicketModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("ticket_category_id")]
        [ForeignKey("TicketCategory")]
        public int TicketCategoryId { get; set; }
        public TicketsCategoryModel? TicketCategory { get; set; }

        [Column("event_schedule_id")]
        [ForeignKey("EventSchedule")]
        public int EventScheduleId { get; set; }
        public EventScheduleModel? EventSchedule { get; set; }

        [Column("number_of_available_tickets")]
        public int NumberOfAvailableTickets { get; set; }

        [Column("price")]
        public double? Price { get; set; }

        [Column("date_created")]
        public DateTime DateCreated { get; set; }

        [Column("date_updated")]
        public DateTime? DateUpdated { get; set; }
    }
}
