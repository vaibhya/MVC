using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CustomerCRUDCoreLib.Data;

namespace CustomerCRUDApp.Models.ViewModel
{
    public class DisplayVm
    {
        public Guid guid { get; set; }
        public String Name { get; set; }
        public String RollNo { get; set; }
        public String Email { get; set; } 
        public List<Customer> CustomerList { get; set; }
    }
}