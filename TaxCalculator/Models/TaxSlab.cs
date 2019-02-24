using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxCalculator.Models
{
    public class TaxSlab
    {
        public int id { get; set; }

        public string Year { get; set; }

        public decimal Amount { get; set; }

        public double InterestRate { get; set; }
    }
}