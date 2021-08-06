using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankMvcApp.Models.ViewModel
{
    public class RegistrationVm
    {
        [Required]
        public String Username { get; set; }
        [Required]
        [Range(500, int.MaxValue, ErrorMessage = "Minimum Deposite amount is 500!")]
        public double Balance { get; set; }
        [Required]
        public String Password { get; set; }
        [Required]
        [Compare("Password")]
        public String ConfirmPassword { get; set; }

        public String SuccessMessage { get; set; }
    }
}