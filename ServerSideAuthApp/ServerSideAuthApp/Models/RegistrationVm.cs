using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServerSideAuthApp.Models
{
    public class RegistrationVm
    {
        [Required]
        public String Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage="Invalid Email!")]
        public String Email { get; set; }

        [Range(18,35, ErrorMessage = "Age should be between 18 to 35")]
        public int Age { get; set; }
        //[Range(15000,Double.MaxValue, ErrorMessage = "Salary should be greater than 15K")]
        [MinSalary(15000,ErrorMessage ="Salary should be greater than 15K")]
        public Double Salary { get; set; }

    }
}