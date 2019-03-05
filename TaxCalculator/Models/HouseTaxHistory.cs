using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaxCalculator.Models
{
    public class HouseTaxHistory
    {
        public int Id { get; set; }

        [Display(Name = "प्रति वर्ग फु दर")]
        public decimal CostPerUnitArea { get; set; }

        //[Required]
        [Display(Name = "आ व")]
        public string FY { get; set; }

        //[Required]
        [Display(Name = "वर्ग फु")]
        public decimal TotalArea { get; set; }

        public string HouseCategory { get; set; }

        //[Display(Name = "")]
        //public decimal LastYearCost { get; set; }
        //[Required]
        [Display(Name = "कायमी मुल्य")]
        public decimal TotalCost { get; set; }
        //[Required]
        [Display(Name = "चालु आ व को कायम मूल्य")]
        public decimal GrossCost { get; set; }
        //[Required]
        [Display(Name = "ह्रासकट्टी प्रतिशत")]
        public decimal DepreciationRate { get; set; }
        //[Required]
        [Display(Name = "ह्रासकट्टी रकम")]
        public decimal DepreciationAmount { get; set; }


        //public int? CitizenId { get; set; }
        //public Citizen Citizen { get; set; }

        public int? CitizenHouseId{ get; set; }
        public CitizenHouse CitizenHouse { get; set; }
    }
}