using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using TaxCalculator.Models;

namespace TaxCalculator.ViewModels
{
    public class LandTaxViewModel
    {
        public int Id { get; set; }

        public CitizenLand CitizenLand { get; set; }

        public LandTaxHistory LandTaxHistory { get; set; }
        
        public LandTaxHistory LastLandTaxHistory { get; set; }

        public  IEnumerable<LandTaxHistory> LandTaxHistories { get; set; }
        public IEnumerable<CitizenLand> CitizenLands { get; set; }
        public IEnumerable<Citizen> Citizens { get; set; }

        [Display(Name = "जग्गाको बनावट")]
        public List<LandValuation> LandValuations { get; set; }

        [Display(Name = "Fiscal Year")]
        public List<FiscalYear> FiscalYears { get; set; }

        [Display(Name = "चारकिल्ला प्रमाणित गरिएको बारे")]
        public HttpPostedFileBase File { get; set; }
        [Display(Name = "घर बाटो खुलाई पठाएको बारे")]
        public HttpPostedFileBase File1 { get; set; }
        [Display(Name = "नाता प्रमाण")]
        public HttpPostedFileBase File2 { get; set; }
        [Display(Name = "विवाह प्रमाण")]
        public HttpPostedFileBase File3 { get; set; }



    }
}