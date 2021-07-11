using System;
using System.Collections.Generic;
using System.Text;

namespace Aisoftware.Tracker.Borders
{
    public class Car
    {
        public Guid ID { get; set; }
        public string Code { get; set; }
        public string LicensePlate { get; set; }
        public string Color { get; set; }
        public Guid TypeID { get; set; }
        public Guid QrCodeID {get;set;}
        public DateTime RegisterDate { get; set; }
        public DateTime AlterDate { get; set; }
        public Guid CompanyID { get; set; }
        public bool Active { get; set; }
    }
}
