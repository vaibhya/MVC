using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentCRUDAppV2.Models.Data;

namespace StudentCRUDAppV2.Models.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public List<Student> _studentList = new List<Student>();
        //private static StudentRepository instance = null;

        public StudentRepository()
        {

            _studentList.Add(new Student { Id = Guid.NewGuid(), Name = "vaibhav", RollNo = "123", Cgpa = 9.7 });
            _studentList.Add(new Student { Id = Guid.NewGuid(), Name = "atul", RollNo = "456", Cgpa = 8.4 });
            _studentList.Add(new Student { Id = Guid.NewGuid(), Name = "akash", RollNo = "789", Cgpa = 7.9 });
            _studentList.Add(new Student { Id = Guid.NewGuid(), Name = "tushar", RollNo = "101", Cgpa = 8.0 });
            _studentList.Add(new Student { Id = Guid.NewGuid(), Name = "sagar", RollNo = "111", Cgpa = 9.0 });
        }
        //public static StudentRepository GetInstance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
         //           instance = new StudentRepository();
         //       }
         //       return instance;
         //   }
        //}

        public List<Student> Get() { return _studentList; }

        public void Add(Student student)
        {
            _studentList.Add(student);
        }
        public void Remove(Student student)
        {
            _studentList.Remove(student);
        }
    }
}