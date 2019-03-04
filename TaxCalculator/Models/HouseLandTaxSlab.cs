using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaxCalculator.Models
{
    public class HouseLandTaxSlab
    {
        [Key]
        public int Id { get; set; }

        public int Sequence { get; set; }

        [Required]
        [Display(Name = "Upper Limit")]
        public decimal UpperLimit { get; set; }

        [Required]
        [Display(Name = "Lower Limit")]
        public decimal LowerLimit { get; set; }

        [Required]
        [Display(Name = "करको रकम")]
        public decimal TaxAmount { get; set; }

        [Required]
        [Display(Name = "करको प्रतिशत")]
        public decimal TaxPercent { get; set; }

        public Boolean FirstSlab { get; set; }



    }
}