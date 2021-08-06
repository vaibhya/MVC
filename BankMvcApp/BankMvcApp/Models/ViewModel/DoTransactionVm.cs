using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankMvcApp.Models.ViewModel
{
    public class DoTransactionVm
    {
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please Enter valid amount")]
        public Double Amount { get; set; }
        [Required]
        public String Activity { get; set; }

        public String Message { get; set; }
    }
}