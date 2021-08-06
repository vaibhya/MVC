using StudentCRUDAppV2.Models.Data;
using StudentCRUDAppV2.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentCRUDAppV2.Models.Service
{
    //public class StudentService : IStudentService
    public class StudentService 
    {
        //private IStudentRepository _repository;
        private StudentRepository _repository;
        public StudentService()
        {
            //_repository = new StudentRepository();
            _repository = new StudentRepository();
        }

        public void AddStudent(Student s)
        {
            _repository.Add(s);
        }

        public void DeleteStudent(Student s)
        {
            _repository.Remove(s);
        }

        public List<Student> GetStudents()
        {
            return _repository.Get();
        }
    }
}