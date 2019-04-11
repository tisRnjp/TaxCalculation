using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaxCalculator.Models;

namespace TaxCalculator.ViewModels
{
    public class HistoryDetailViewModel
    {
        public CitizenHouse CitizenHouse { get; set; }
        public HouseTaxHistory HouseTaxHistory { get; set; }

        public LandTaxHistory LandTaxHistory { get; set; }
    }
}
