using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketService.Migrations.Models
{
    public class OrderEFModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public required UserModelEF User { get; set; }
        public int EventId { get; set; }
        public required EventEFModel Event { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
    }
}
