using CustomerCRUDCoreLib.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRUDCoreLib.Repository
{
    public class CustomerRepository : DbContext, ICustomerRepository
    {
        public CustomerRepository() 
        {
            Database.SetInitializer<CustomerRepository>(new CreateDatabaseIfNotExists<CustomerRepository>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<CustomerRepository>());
        }
        public DbSet<Customer> Customers { get; set; }

        public void Add(Customer customer)
        {
            Customers.Add(customer);
            this.SaveChanges();
        }
        public void Delete(Customer customer)
        {
            Customers.Remove(customer);
            this.SaveChanges();
        }
        public void Update(Customer customer,Guid guid)
        {
            Customer updateCustomer = this.Find(guid);
            updateCustomer = customer;
            this.SaveChanges();
            
        }
        public List<Customer> Get()
        {
            return Customers.ToList<Customer>();
        }
        public Customer Find(Guid guid)
        {
            var cust = Customers.Find(guid);
            return cust;
        }
        public bool FindEmail(Guid guid)
        {
            var cust = this.Find(guid);
            if (cust == null)
            {
                return false;
            }
            return true;
        }
    }
}
