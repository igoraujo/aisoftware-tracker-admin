using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aisoftware.Tracker.Borders.ViewModels
{
    public class ActiveTravelsPerDay
    {
        [Column("id")]
        public string ID { get; set; }
        [Column("driverid")]
        public string DriverID { get; set; }
        [Column("lineid")]
        public string LineID { get; set; }
        [Column("driver")]
        public string Driver { get; set; }
        [Column("licenseplate")]
        public string LicensePlate { get; set; }
        [Column("line")]
        public string Number { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("price")]
        public double Price { get; set; }
        [Column("starttime")]
        public DateTime StartTime { get; set; }
        [Column("finishtime")]
        public string FinishTime { get; set; }
    }
}
