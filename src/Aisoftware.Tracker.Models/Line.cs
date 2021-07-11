using System;
using System.Collections.Generic;
using System.Text;

namespace Aisoftware.Tracker.Models
{
    public class Line
    {
        public Guid ID { get; set; }
        public string Number { get; set; }
        public Guid TicketID { get; set; }
        public string Description { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime AlterDate { get; set; }
        public bool Active { get; set; }
    }
}
