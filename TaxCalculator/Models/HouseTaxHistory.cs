using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxCalculator.Models
{
    public class HouseTaxHistory
    {
        public int Id { get; set; }

        

        public decimal CurrentCost { get; set; }

        public decimal LastYearCost { get; set; }

        public decimal GrossCost
        {
            get
            {
                return CurrentCost * CitizenHouse.Area - DepreciationAmount;
            }
        }

        public decimal DepreciationRate { get; set; }

        

        public decimal DepreciationAmount
        {
            get
            {
                return (DepreciationRate / 100) * CurrentCost;
            }
        }


        public int? CitizenHouseId{ get; set; }
        public CitizenHouse CitizenHouse { get; set; }
    }
}