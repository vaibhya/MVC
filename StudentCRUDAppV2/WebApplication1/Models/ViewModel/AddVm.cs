using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentCRUDAppV2.Models.ViewModel
{
    public class AddVm
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string RollNo { get; set; }
        [Required]
        [Range(1, 10)]
        public double Cgpa { get; set; }
    }
}