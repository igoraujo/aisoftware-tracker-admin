using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text;

namespace Aisoftware.Tracker.Borders
{
    public class User
    {
        [Column("id")]
        public string Id { get; set; }
        
        [Column("companyid")]
        public string CompanyId { get; set; }
        
        [Column("profileid")]
        public int ProfileId { get; set; }
        
        [Column("name")]
        public string Name { get; set; }
        
        [Column("socialnumber")]
        public string SocialNumber { get; set; }
        
        [Column("birthdate")]
        public DateTime BirthDate { get; set; }
        
        [Column("email")]
        public string Email { get; set; }
        
        [Column("password")]
        public string Password { get; set; }
        
        [Column("token")]
        public string Token { get; set; }
        
        [Column("cellphone")]
        public string Cellphone { get; set; }
        
        [Column("cityid")]
        public string CityID { get; set; }
        
        [Column("registerdate")]
        public DateTime RegisterDate { get; set; }
        
        [Column("alterdate")]
        public DateTime? AlterDate { get; set; }
        
        [Column("firstlogin")]
        public bool FirstLogin { get; set; }
        
        [Column("active")]
        public bool Active { get; set; }
        
        [Column("image")]
        public string Image { get; set; }
    }
}
