using System;

namespace Aisoftware.Tracker.Models
{
    public class Balance
    {
        public Guid ID { get; set; }
        public Guid PassengerID { get; set; }
        public Guid TravelPassengerID { get; set; }
        public string Detail { get; set; }
        public decimal Value { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}