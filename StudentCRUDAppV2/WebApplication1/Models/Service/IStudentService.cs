using StudentCRUDAppV2.Models.Data;

namespace StudentCRUDAppV2.Models.Service
{
    public interface IStudentService
    {
        void AddStudent(Student s);
        void DeleteStudent(Student s);
        System.Collections.Generic.List<Student> GetStudents();
    }
}