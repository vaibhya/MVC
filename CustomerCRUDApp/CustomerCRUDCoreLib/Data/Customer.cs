using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRUDCoreLib.Data
{
    public class Customer
    {
        [Key]
        public Guid guid { get; set; } 
        public String Name { get; set; }
        public String Location { get; set; }
        public String Email { get; set; }

    }
}
