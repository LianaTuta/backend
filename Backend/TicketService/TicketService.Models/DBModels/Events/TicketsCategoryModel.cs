namespace TicketService.Models.DBModels.Events
{
    public class TicketsCategoryModel
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
