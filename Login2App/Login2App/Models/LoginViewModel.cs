using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login2App.Models
{
    public class LoginViewModel
    {
        public String UserName { get; set; }
        public String UserPassword { get; set; }

        public String ErrorMessage { get; set; }
    }
}