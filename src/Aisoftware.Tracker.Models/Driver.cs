using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aisoftware.Tracker.Models
{
    public class Driver
    {
        [Column("id")]
        public string ID { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("socialnumber")]
        public string SocialNumber { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("token")]
        public string Token { get; set; }

        [Column("cellphone")]
        public string Cellphone { get; set; }

        [Column("birthdate")]
        public DateTime? BirthDate { get; set; }

        [Column("companyid")]
        public string CompanyID { get; set; }

        [Column("licenseid")]
        public string LicenseID { get; set; }

        [Column("registerdate")]
        public DateTime RegisterDate { get; set; }

        [Column("alterdate")]
        public DateTime? AlterDate { get; set; }

        [Column("active")]
        public bool Active { get; set; }
    }
}
