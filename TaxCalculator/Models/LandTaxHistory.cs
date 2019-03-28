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

        [Display(Name = "आ व देखि")]
        public string  FromFY { get; set; }

        [Display(Name = "आ व सम्म")]
        public string ToFY { get; set; }

        public decimal MyProperty { get; set; }

        [Display(Name = "FAR अनुसार को क्ष फ")]  //x /1.75/342.25
        public decimal ValuationArea { get; set; }

        [Display(Name = "मुल्यांकन हुने क्ष फ")]  //x /1.75/342.25
        public decimal ActualValuationArea { get; set; }

        [Display(Name = "कैफियत")]  //x /1.75/342.25
        public string Remarks { get; set; }

        [Display(Name = "प्रति व मी दर")]
        public decimal CostPerUnitArea { get; set; }

        public string LandCategory { get; set; }

        [Display(Name = "कायम मूल्य")]
        public decimal TotalCost
        {
            get;set;
        }


        [Display(Name = "गत आ व को प्रति व मी दर")]
        public decimal? LastFYCostPerUnitArea { get; set; }

        [Display(Name = "गत आ व को कायम मूल्य")]
        public decimal? LastFYTotalCost { get; set; }


        [Display(Name = "Citizen ")]
        public int? CitizenId { get; set; }
        public Citizen Citizen { get; set; }

        [Display(Name = "Land ")]
        public int? CitizenLandId { get; set; }
        public CitizenLand CitizenLand { get; set; }

        [Display(Name = "कित्ता नम्बर")]
        public string KittaNo { get; set; }

        [Display(Name = "House Tax")]
        public int? HouseTaxHistoryId { get; set; }
        public HouseTaxHistory HouseTaxHistory { get; set; }

        [Display(Name = "आ व देखि")]
        public int? FromFiscalYearId { get; set; }
        public FiscalYear FromFiscalYear { get; set; }

        public int? ToFiscalYearId { get; set; }
        [Display(Name = "आ व सम्म")]
        public FiscalYear ToFiscalYear { get; set; }

    }
}