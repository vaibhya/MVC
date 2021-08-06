using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankMvcApp.Models.Service
{
    public class Transaction
    {
        private String _amount;
        private String _type;
        private String _datetime;
        public Transaction(String amount,String type,String datetime)
        {
            _amount = amount;
            _type = type;
            _datetime = datetime;
        }
        public String Amount
        {
            get { return _amount; }
        }
        public String Type
        {
            get { return _type; }
        }
        public String Datetime
        {
            get { return _datetime; }
        }
    }
}