using System;
using System.Collections.Generic;
using System.Text;

namespace Aisoftware.Tracker.Models
{
    public class City
    {
        public Guid ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string UF { get; set; }
        public string Zip { get; set; }
        public Guid StateID {get;set;}

    }
}
