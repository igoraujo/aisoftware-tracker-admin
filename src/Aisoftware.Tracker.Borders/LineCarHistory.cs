using System;
using System.Collections.Generic;
using System.Text;

namespace Aisoftware.Tracker.Borders
{
    public class LineCarHistory
    {
        public Guid ID { get; set; }
        public Guid CarID { get; set; }
        public Guid LineID { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime AlterDate { get; set; }
    }
}
