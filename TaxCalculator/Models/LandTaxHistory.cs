using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaxCalculator.Models
{
    public class LandTaxHistory
    {
        public int Id { get; set; }

        [Display(Name = "आ व")]
        public string  FY { get; set; }

        public decimal MyProperty { get; set; }

        [Display(Name = "मुल्यांकन हुने क्ष फ")]
        public decimal ValuationArea { get; set; }

        [Display(Name = "प्रति व मी दर")]
        public decimal CostPerUnitArea { get; set; }

        [Display(Name = "कायम मूल्य")]
        public decimal TotalCost
        {
            get;set;
        }

        [Display(Name = "Citizen ")]
        public int? CitizenId { get; set; }
        public Citizen Citizen { get; set; }

        [Display(Name = "Land ")]
        public int? CitizenLandId { get; set; }
        public CitizenLand CitizenLand { get; set; }

    }
}