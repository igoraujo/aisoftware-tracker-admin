using System;
using System.Collections.Generic;
using System.Text;

namespace Aisoftware.Tracker.Borders
{
    public class TravelPassenger
    {
        public Guid ID { get; set; }
        public Guid PassengerID { get; set; }
        public Guid TravelID { get; set; }
        public decimal PriceTicket { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
