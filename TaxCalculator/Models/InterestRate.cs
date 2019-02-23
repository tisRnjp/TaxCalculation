using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxCalculator.Models
{
    public class InterestRate
    {
        public int Id { get; set; }

        public String Year { get; set; }

        public Double Percentage { get; set; }

        public String PropertyType { get; set; }
    }
}