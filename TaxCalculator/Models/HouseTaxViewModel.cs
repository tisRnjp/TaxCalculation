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

        public HouseTaxHistory houseTaxHistory { get; set; }

        public IEnumerable<HouseTaxHistory> HouseTaxHistories { get; set; }

        public IEnumerable<CitizenHouse> CitizenHouses { get; set; }
        


        //public decimal CurrentCost { get; set; }

        //public decimal LastYearCost { get; set; }

        //public decimal GrossCost {
        //    get
        //    {
        //        return CurrentCost * CitizenHouse.Area - DepreciationAmount;
        //    }
        //}

        //public decimal DepreciationRate { get; set; }

        //public decimal DepreciationRateLastYear { get; set; }

        //public decimal DepreciationAmount {
        //    get
        //    {
        //        return (DepreciationRate / 100) * CurrentCost; 
        //    }
        //}

    }
}