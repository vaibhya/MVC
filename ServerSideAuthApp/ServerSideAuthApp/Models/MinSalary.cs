using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServerSideAuthApp.Models
{
    public class MinSalary: ValidationAttribute
    {
        private double _minSalary;
        public MinSalary(Double salary)
        {
            _minSalary = salary;
        }
        public override bool IsValid(object value)
        {
            double inputSalary = Convert.ToDouble(value);
            return inputSalary>_minSalary;
        }
    }
}