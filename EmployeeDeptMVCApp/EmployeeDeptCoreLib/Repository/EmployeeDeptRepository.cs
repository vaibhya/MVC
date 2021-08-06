using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeDeptCoreLib.Data;

namespace EmployeeDeptCoreLib.Repository
{
    public class EmployeeDeptRepository : IEmployeeDeptRepository
    {
        private SqlConnection _sqlConn;
        private List<Dept> _dept;
        private List<Employee> _emp;
        private List<int> _deptId;
        private List<string> _deptName;
        public EmployeeDeptRepository()
        {
            String connectionString = ConfigurationManager.ConnectionStrings["EmployeeDeptRepository"].ToString();
            _sqlConn = new SqlConnection(connectionString);
            _sqlConn.Open();
        }
        public IEnumerable<Dept> GetDept()
        //public SelectList<De GetDept()
        {
            _dept = new List<Dept>();
            SqlCommand deptCmd = new SqlCommand("select * from Dept ", _sqlConn);
            SqlDataReader reader = deptCmd.ExecuteReader();
            while (reader.Read())
            {

                _dept.Add(new Dept { Dname = reader["DNAME"].ToString(), DeptNo = int.Parse(reader["DEPTNo"].ToString()), Location = reader["LOC"].ToString() });

            }
            reader.Close();
            return _dept;
        }
        public List<int> GetDeptId()
        {
            _deptId = new List<int>();
            //List<Dept> deptList = this.GetDept();
            IEnumerable<Dept> deptList = this.GetDept();
            foreach (var dept in deptList)
            {
                _deptId.Add(dept.DeptNo);
            }
            return _deptId;
        }
        public List<string> GetDeptName()
        {
            _deptName = new List<string>();
            //List<Dept> deptList = this.GetDept();
            IEnumerable<Dept> deptList = this.GetDept();
            foreach (var dept in deptList)
            {
                _deptName.Add(dept.Dname);
            }
            return _deptName;
        }
        public List<Employee> GetEmp()
        {
            _emp = new List<Employee>();
            SqlCommand deptCmd = new SqlCommand("select * from Emp ", _sqlConn);
            SqlDataReader reader = deptCmd.ExecuteReader();
            while (reader.Read())
            {
                string comm = "null";
                string empno = reader["EMPNO"].ToString();
                string empname = reader["ENAME"].ToString();
                string job = reader["JOB"].ToString();
                string mgrId = reader["MGR"].ToString();
                string datetime = reader["HIREDATE"].ToString();
                
                int deptNo = int.Parse(reader["DEPTNO"].ToString());
                string salary = reader["SAL"].ToString();
                //if(reader["COMM"].ToString() == "NULL")
                //{
                    
                 //   comm = "0";
                //}
                if(reader["COMM"].ToString() != "NULL")
                {
                    comm = reader["COMM"].ToString();
                }
                 
                _emp.Add(new Employee { EmpNo = empno, Ename = empname, Job = job, ManagerId = mgrId, HireDateTime = datetime, Comission = comm, DeptNo = deptNo, Salary = salary });

            }
            reader.Close();
            return _emp;
        }

    }
}
