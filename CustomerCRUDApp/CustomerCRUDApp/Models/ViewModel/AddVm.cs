using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerCRUDApp.Models.ViewModel
{
    public class AddVm
    {
        public Guid guid { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Location { get; set; }
        [Required]
        [EmailAddress]
        public String Email { get; set; }
    }
}