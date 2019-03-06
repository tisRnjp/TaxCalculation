using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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


    }
}