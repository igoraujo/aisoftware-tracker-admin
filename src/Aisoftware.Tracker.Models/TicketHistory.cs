using System;
using System.Collections.Generic;
using System.Text;

namespace Aisoftware.Tracker.Models
{
    public class TicketHistory
    {
        public Guid ID { get; set; }
        public decimal Price { get; set; }
        public Guid TicketID { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime AlterDate { get; set; }
    }
}
