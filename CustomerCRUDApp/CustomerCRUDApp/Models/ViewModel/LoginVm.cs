using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerCRUDApp.Models.ViewModel
{
    public class LoginVm
    {
        [Required]
        public Guid Guid { get; set; }
        public string FailMessage { get; set; }
    }
}