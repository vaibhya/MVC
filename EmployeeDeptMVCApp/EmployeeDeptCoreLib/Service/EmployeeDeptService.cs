using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeDeptCoreLib.Data;
using EmployeeDeptCoreLib.Repository;

namespace EmployeeDeptCoreLib.Service
{
    public class EmployeeDeptService : IEmployeeDeptService
    {
        private IEmployeeDeptRepository _repo;
        public EmployeeDeptService()
        {
            _repo = new EmployeeDeptRepository();
        }
        public List<Employee> GetEmployees(int deptId)
        {
            List<Employee> selectedEmp = new List<Employee>();
            List<Employee> employees = _repo.GetEmp();
            foreach (var emp in employees)
            {
                if (emp.DeptNo == deptId)
                {
                    selectedEmp.Add(emp);
                }
            }
            return selectedEmp;
        }
        public IEnumerable<Dept> GetDept()
        //public SelectList<Dept> GetDept()
        {
            return _repo.GetDept();
        }
        public List<String> GetDeptName()
        {
            return _repo.GetDeptName();
        }
        public List<int> GetDeptId()
        {
            return _repo.GetDeptId();
        }
    }
}
