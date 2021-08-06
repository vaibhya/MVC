using StudentCRUDAppV2.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentCRUDAppV2.Models.ViewModel
{
    public class UpdateVm
    {
        public Guid guid { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String RollNo { get; set; }
        [Required]
        [Range(1, 10)]
        public Double Cgpa { get; set; }

        public Student student { get; set; }
    }
}