using System;
using System.Collections.Generic;
using System.Text;

namespace Aisoftware.Tracker.Borders
{
    public class State
    {
        public Guid ID { get; set; }
        public Guid CountryID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string UF { get; set; }
        public string Region { get; set; }
    }
}
