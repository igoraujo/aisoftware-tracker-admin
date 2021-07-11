using System;
using System.Collections.Generic;
using System.Text;

namespace Aisoftware.Tracker.Borders
{
    public class QrCode
    {
        public Guid ID { get; set; }
        public string Code { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool Active { get; set; }
    }
}
