using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketService.Models.RequestModels.Order
{
    public class OrderRequest
    {
        public int EventId {  get; set; }
        public DateTime StartDate { get; set; }
    }
}
