using System;
using System.Collections.Generic;
using System.Text;

namespace Aisoftware.Tracker.Borders
{
    public class Company
    {
        public Guid ID { get; set; }
        public Guid CompanyID { get; set; }
        public string LoginCompanyID { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime AlterDate { get; set; }
        public bool Active { get; set; }
    }
}
