using EmployeeDeptCoreLib.Data;
using System.Collections.Generic;

namespace EmployeeDeptCoreLib.Repository
{
    public interface IEmployeeDeptRepository
    {
        //List<Dept> GetDept();
        IEnumerable<Dept> GetDept();
        List<Employee> GetEmp();
        List<int> GetDeptId();

        List<string> GetDeptName();
    }
}