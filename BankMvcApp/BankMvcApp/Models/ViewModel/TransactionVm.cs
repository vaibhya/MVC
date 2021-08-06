using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankMvcApp.Models.ViewModel
{
    public class TransactionVm
    {
        public String Amount { get; set; }
        public String Type { get; set; }
        public String DateTime { get; set; }
    }
}