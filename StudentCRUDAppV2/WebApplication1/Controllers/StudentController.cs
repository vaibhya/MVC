using StudentCRUDAppV2.Models.Data;
using StudentCRUDAppV2.Models.Service;
using StudentCRUDAppV2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentCRUDAppV2.Models.Repository;

namespace StudentCRUDAppV2.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService _service;
        public StudentController(IStudentService service)
        {
            _service = service;
        }

        public ActionResult Home()
        {
            //StudentService service = new StudentService();
            DisplayVm vm = new DisplayVm();
            vm.StudentList = _service.GetStudents();

            return View(vm);
        }

        public ActionResult Add()
        {
            AddVm vm = new AddVm();
            return View(vm);
        }
        [HttpPost]
        public ActionResult Add(AddVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            Student student = new Student { Name = vm.Name, RollNo = vm.RollNo, Cgpa = vm.Cgpa, Id = Guid.NewGuid() };
            //StudentService service = new StudentService();
            _service.AddStudent(student);

            return RedirectToAction("Home");
        }
        [Route("Home/Update/{Id}")]
        public ActionResult Update(Guid Id)
        {
            UpdateVm vm = new UpdateVm();
            //StudentService service = new StudentService();
            List<Student> studentList = _service.GetStudents();
            foreach (var student in studentList)
            {
                if (Id == student.Id)
                {
                    vm.Name = student.Name;
                    vm.RollNo = student.RollNo;
                    vm.Cgpa = student.Cgpa;

                    Session["id"] = student.Id;
                }
            }
            return View(vm);
        }
        [HttpPost]

        public ActionResult Update(UpdateVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            //StudentService service = new StudentService();
            List<Student> studentList = _service.GetStudents();
            foreach (var student in studentList)
            {
                if (Session["id"].ToString() == student.Id.ToString())
                {
                    student.Name = vm.Name;
                    student.RollNo = vm.RollNo;
                    student.Cgpa = vm.Cgpa;

                }
            }
            return RedirectToAction("Home");

        }
    }
}