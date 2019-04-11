using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxCalculator.Models
{
    public class TaxHistory
    {
        public int Id { get; set; }
        public int CitizenId { get; set; }
        //house
        public decimal HousTotalArea { get; set; }
        public decimal HousGrossCost { get; set; }
        public decimal? HousLastFYGrossCost { get; set; }
        public string ToFY { get; set; }
        public string FromFY { get; set; }

        //house
        public string LandTaxKittaNo { get; set; }
        public int? LandTaxLastFYCost { get; set; }
        public decimal LandTaxCost { get; set; }
        public decimal LandTaxArea { get; set; }

        //Tax
        public decimal TotalValuation { get; set; }
        public decimal TotalTax { get; set; }
        public DateTime Date { get; set; }

    }
}