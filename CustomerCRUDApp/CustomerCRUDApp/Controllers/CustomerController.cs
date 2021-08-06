using CustomerCRUDApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerCRUDCoreLib.Service;
using CustomerCRUDCoreLib.Data;

namespace CustomerCRUDApp.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerService _service;
        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        //[Authorize]
        //[Route("Customer/Home")]
        public ActionResult Home()
        {
            DisplayVm vm = new DisplayVm();
            vm.CustomerList = _service.GetCustomers();
            
            return View(vm);
        }
        [Authorize]
        public ActionResult Add()
        {
            AddVm vm = new AddVm();
            return View(vm);
        }
        [HttpPost]
        public ActionResult Add(AddVm vm)
        {
            if (!this.ModelState.IsValid)
            {
                return View(vm);
            }
            _service.AddCustomer(new Customer { guid = Guid.NewGuid(), Name = vm.Name, Email = vm.Email, Location = vm.Location });
            return RedirectToAction("Home");

        }
        public ActionResult Delete(Guid id)
        {

            Customer customer = _service.FindCustomer(id);
            _service.DeleteCustomer(customer);
            return RedirectToAction("Home");
        }
        public ActionResult Update(Guid id)
        {
            UpdateVm vm = new UpdateVm();
            Customer customer = _service.FindCustomer(id);
            vm.Name = customer.Name;
            vm.Email = customer.Email;
            vm.Location = customer.Location;
            Session["id"] = id;
            return View(vm);
            
        }
        [HttpPost]
        public ActionResult Update(UpdateVm vm)
        {
            if (!this.ModelState.IsValid)
            {
                return View(vm);
            }
            Guid guid =  Guid.Parse(Session["id"].ToString());
            Customer customer = _service.FindCustomer(guid);
            customer.Name = vm.Name;
            customer.Email = vm.Email;
            customer.Location = vm.Location;
            _service.UpdateCustomer(customer,guid);
            
            return RedirectToAction("Home");
        }
    }
}