using System;
using System.Collections.Generic;
using System.Text;

namespace Aisoftware.Tracker.Borders
{
    public class CompanyHistory
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string IndividualRegistration { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid Token {get;set;}
        public string Cellphone { get; set; }
        public Guid CityID { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime AlterDate { get; set; }
        public bool Active { get; set; }
    }
}
