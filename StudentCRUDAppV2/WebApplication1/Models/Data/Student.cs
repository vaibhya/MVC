using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentCRUDAppV2.Models.Data
{
    public class Student
    {
        public Guid Id { get; set; }
        public String RollNo { get; set; }
        public String Name { get; set; }
        public Double Cgpa { get; set; }
    }
}