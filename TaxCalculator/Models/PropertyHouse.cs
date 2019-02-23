using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxCalculator.Models
{
    public class PropertyHouse
    {
        public int Id { get; set; }

        public double Area { get; set; }

        public double Story { get; set; }

        public decimal RatePerSquareFoot { get; set; }

        public int CitizenId { get; set; }
        public Citizen Citizen { get; set; }
    }
}