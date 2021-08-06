using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDeptCoreLib.Data
{
    public class Employee
    {
        public string EmpNo { get; set; }
        public string Ename { get; set; }
        public string Job { get; set; }
        public string ManagerId { get; set; }
        public string HireDateTime { get; set; }
        public string Salary { get; set; }
        public string Comission { get; set; }
        public int DeptNo { get; set; }
    }
}
