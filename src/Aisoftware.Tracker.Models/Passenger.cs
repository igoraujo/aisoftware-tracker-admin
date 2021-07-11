using System;
using System.Collections.Generic;
using System.Text;

namespace Aisoftware.Tracker.Models
{
    public class Passenger
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string SocialNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid Token { get; set; }
        public string CellPhone { get; set; }
        public Guid CityID { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime AlterDate { get; set; }
    }
}
