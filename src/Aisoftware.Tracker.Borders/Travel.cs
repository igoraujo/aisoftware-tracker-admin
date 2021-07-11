using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aisoftware.Tracker.Borders
{
    public class Travel
    {
        [Column("id")]
        public string ID { get; set; }
        [Column("driverid")]
        public string DriverID { get; set; }
        [Column("caridid")]
        public string CarID { get; set; }
        [Column("lineid")]
        public string LineID { get; set; }
        [Column("starttime")]
        public DateTime StartTime { get; set; }
        [Column("finishline")]
        public DateTime FinishTime { get; set; }
        [Column("active")]
        public bool Active { get; set; }
    }
}
