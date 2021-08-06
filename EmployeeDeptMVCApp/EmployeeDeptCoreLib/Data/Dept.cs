using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDeptCoreLib.Data
{
    public class Dept
    {
        [Key]
        public int DeptNo { get; set; }
        public string Dname { get; set; }
        public string Location { get; set; }

        //[NotMapped]
        //public SelectList DeptData { get; set; }

    }
}
