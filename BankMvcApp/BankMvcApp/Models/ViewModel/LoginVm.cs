using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankMvcApp.Models.ViewModel
{
    public class LoginVm
    {
        [Required]
        public String Username { get; set; }
        [Required]
        public String Password { get; set; }

        public String FailMessage { get; set; }

        
    }
}