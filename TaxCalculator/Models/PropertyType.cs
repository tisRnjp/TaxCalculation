using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxCalculator.Models
{
    public class PropertyType
    {
        public int Id { get; set; }

        public String Type { get; set; }

        public decimal DepriciationRate { get; set; }

        public String FiscalYear { get; set; }

        public Decimal PropertyCost{ get; set; }
    }
}