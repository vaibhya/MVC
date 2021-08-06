using System.Collections.Generic;
using StudentCRUDAppV2.Models.Data;

namespace StudentCRUDAppV2.Models.Repository
{
    public interface IStudentRepository
    {
        void Add(Student student);
        List<Student> Get();
        void Remove(Student student);
    }
}