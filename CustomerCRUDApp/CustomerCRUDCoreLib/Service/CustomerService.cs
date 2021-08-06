using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerCRUDCoreLib.Data;
using CustomerCRUDCoreLib.Repository;

namespace CustomerCRUDCoreLib.Service
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _repo;
        public CustomerService()
        {
            _repo = new CustomerRepository();
        }
        public void AddCustomer(Customer customer)
        {
            _repo.Add(customer);
            
        }
        public void UpdateCustomer(Customer customer,Guid guid)
        {
            _repo.Update(customer,guid);
        }
        public void DeleteCustomer(Customer customer)
        {
            _repo.Delete(customer);
        }
        public List<Customer> GetCustomers()
        {
            return _repo.Get();
        }
        public Customer FindCustomer(Guid guid)
        {
            return _repo.Find(guid);
        }
        public bool AuthenticateEmail(Guid guid)
        {
            return _repo.FindEmail(guid);
        }
    }
}
