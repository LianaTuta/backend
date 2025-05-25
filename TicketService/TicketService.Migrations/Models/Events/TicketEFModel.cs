using System.ComponentModel.DataAnnotations.Schema;

namespace TicketService.Migrations.Models.Events
{
    public class TicketEFModel
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public required string Name { get; set; }

        [Column("description")]
        public required string Description { get; set; }

        [Column("ticket_category_id")]
        public int TicketCategoryId { get; set; }
        public required TicketCategoryEFModel TicketCategory { get; set; }

        [Column("event_schedule_id")]
        public int EventScheduleId { get; set; }
        public required EventScheduleEFModel EventSchedule { get; set; }

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
