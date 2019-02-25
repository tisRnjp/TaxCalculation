using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxCalculator.Models
{
    public class HouseTaxViewModel
    {
        public int Id { get; set; }

        public CitizenHouse CitizenHouse { get; set; }

        public HouseTaxHistory HouseTax { get; set; }

        public List<HouseTaxHistory> HouseTaxHistories { get; set; }

        public HouseTaxHistory LastHouseTax { get; set; }

    }
}