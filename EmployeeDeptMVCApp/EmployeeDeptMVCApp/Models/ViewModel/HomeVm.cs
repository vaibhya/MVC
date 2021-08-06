using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeDeptCoreLib.Data;
namespace EmployeeDeptMVCApp.Models.ViewModel
{
    public class HomeVm
    {
        //public List<Dept> DeptList { get; set; }
        public SelectList DeptList { get; set; }

        public List<String> DeptName { get; set; }
        public int DeptId { get; set; }

        public List<Employee> EmpList { get; set; }
    }
}