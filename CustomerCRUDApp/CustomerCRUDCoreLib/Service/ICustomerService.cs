using CustomerCRUDCoreLib.Data;
using System;
using System.Collections.Generic;

namespace CustomerCRUDCoreLib.Service
{
    public interface ICustomerService
    {
        void AddCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        List<Customer> GetCustomers();
        void UpdateCustomer(Customer customer,Guid guid);

        Customer FindCustomer(Guid guid);
        bool AuthenticateEmail(Guid guid);
    }
}