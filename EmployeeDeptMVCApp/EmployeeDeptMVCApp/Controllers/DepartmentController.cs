using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using EmployeeDeptCoreLib.Data;
using EmployeeDeptCoreLib.Service;
using EmployeeDeptMVCApp.Models.ViewModel;

namespace EmployeeDeptMVCApp.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        private IEmployeeDeptService _service;
        public DepartmentController(IEmployeeDeptService service)
        {
            _service = service;
        }
        public ActionResult Home()
        {
            HomeVm vm = new HomeVm();
            vm.DeptList = new SelectList(_service.GetDept(), "DEPTNO", "DNAME");
            //Session["deptlist"] = new SelectList(_service.GetDept(), "DEPTNO", "DNAME");
            vm.EmpList = null;
            return View(vm);
        }
        [HttpPost]
        public ActionResult Home(HomeVm vm)
        {
            int deptId = vm.DeptId;
            ViewBag.list = _service.GetEmployees(deptId);
            vm.DeptList = new SelectList(_service.GetDept(), "DEPTNO", "DNAME");    
            return View(vm);
        }
    }
}