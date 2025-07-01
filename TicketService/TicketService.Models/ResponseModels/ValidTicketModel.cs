namespace TicketService.Models.ResponseModels
{
    public class ValidTicketModel
    {
        public bool IsValid { get; set; }
        public int RemainingTIckets { get; set; }

        public int SoldTickets { get; set; }

    }
}
