using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaxCalculator.Models
{
    public class CitizenHouse
    {
        public int Id { get; set; }

        [Display(Name = "लम्बाई ")]
        public decimal Length { get; set; }

        [Display(Name = "चौडाई ")]
        public decimal Width { get; set; }

        [Display(Name = "वर्ग फूट")]
        public decimal Area { get; set; }

        [Display(Name = "तल्ला")]
        public decimal Floor { get; set; }

        //public String BatoKoPrakar { get; set; }


        [Display(Name = "नागरिकता नम्बर")]
        public int? CitizenId { get; set; }
        public Citizen citizen { get; set; }
    }
}