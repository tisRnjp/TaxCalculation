using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxCalculator.Models
{
    public class Depreciation
    {
        public int Id { get; set; }

        public string Year { get; set; }

        public decimal Percentage { get; set; }

        public string PropertyType { get; set; }
    }
}