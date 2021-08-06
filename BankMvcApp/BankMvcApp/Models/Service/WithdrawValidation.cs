using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace BankMvcApp.Models.Service
{
    public class WithdrawValidation
    {
        private double _amount;
        private double _balance;
        
        public WithdrawValidation(Double amount, Double balance)
        {
            _amount = amount;
            _balance = balance;
        }
        public bool ValidateAmoumt()
        {
            if (_balance - _amount < 500)
            {
                return false;
            }
            return true;
        }
    }
}