﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Aisoftware.Tracker.Borders
{
    public class UserCompanyHistory
    {
        public Guid ID { get; set; }
        public Guid CompanyID { get; set; }
        public Guid UserCompanyID { get; set; }
        public Guid ProfileID { get; set; }
        public string Name { get; set; }
        public string SocialNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid Token { get; set; }
        public string Cellphone { get; set; }
        public Guid CityID { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime AlterDate { get; set; }
        public bool FirstLogin { get; set; }
        public bool Active { get; set; }
    }
}