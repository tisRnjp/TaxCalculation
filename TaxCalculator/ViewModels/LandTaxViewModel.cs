using System;
using System.Collections.Generic;
using System.Linq;
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



    }
}