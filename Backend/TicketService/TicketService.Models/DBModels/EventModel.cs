using System.ComponentModel.DataAnnotations.Schema;

namespace TicketService.Models.DBModels
{
    [Table("Event")]
    public class EventModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int EventTypeId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
