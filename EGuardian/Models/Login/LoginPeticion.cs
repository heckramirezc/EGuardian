using System;
using System.Collections.Generic;
using System.Text;

namespace EGuardian.Models.Login
{
    public class Login
    {
        public string username { get; set; }
        public string password { get; set; }
        public string parametros { get { return "username=" + username + "&password=" + password; } }
    }

    public class LoginResponse
    {
        public string id { get; set; }
        public string userId { get; set; }
        public string customer_id { get; set; }
        public string email { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string gender { get; set; }
        public string token { get; set; }
        public string membershipNumber { get; set; }
        public double currentBalance { get; set; }
    }
}