using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMvcCoreLib.Data
{
    public class Transaction
    {
        public string Username { get; set; }
        public double Amount { get; set; }
        public string Type { get; set; }
        public string Datetime { get; set; }

    }
}
