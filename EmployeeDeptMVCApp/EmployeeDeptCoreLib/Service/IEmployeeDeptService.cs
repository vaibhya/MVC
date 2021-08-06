using EmployeeDeptCoreLib.Data;
using System.Collections.Generic;

namespace EmployeeDeptCoreLib.Service
{
    public interface IEmployeeDeptService
    {
        List<Employee> GetEmployees(int deptId);

        //List<Dept> GetDept();
        IEnumerable<Dept> GetDept();
        List<string> GetDeptName();
        List<int> GetDeptId();

    }
}