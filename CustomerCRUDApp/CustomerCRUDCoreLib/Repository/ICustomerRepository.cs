using CustomerCRUDCoreLib.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace CustomerCRUDCoreLib.Repository
{
    public interface ICustomerRepository
    {
        DbSet<Customer> Customers { get; set; }

        void Add(Customer customer);

        void Delete(Customer customer);
        void Update(Customer customer,Guid guid);

        List<Customer> Get();

        Customer Find(Guid guid);
        bool FindEmail(Guid guid);


    }
}