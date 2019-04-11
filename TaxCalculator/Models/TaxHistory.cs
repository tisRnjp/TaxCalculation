using System;

namespace TaxCalculator.Models
{
    public class TaxHistory
    {
        public int Id { get; set; }
        public int CitizenId { get; set; }
        public int HoustTaxId { get; set; }
        public int LandTaxId { get; set; }

        //house
        public decimal HousTotalArea { get; set; }
        public decimal HousGrossCost { get; set; }
        public decimal? HousLastFYGrossCost { get; set; }
        public string ToFY { get; set; }
        public string FromFY { get; set; }
        public int? TotalYears { get; set; }

        //house
        public string LandTaxKittaNo { get; set; }
        public decimal? LandTaxLastFYCost { get; set; }
        public decimal LandTaxCost { get; set; }
        public decimal LandTaxArea { get; set; }

        //Tax

        public decimal LastFYTotalValuation { get; set; }
        public decimal TotalValuation { get; set; }
        public decimal TotalTax { get; set; }
        public DateTime Date { get; set; }

    }
}