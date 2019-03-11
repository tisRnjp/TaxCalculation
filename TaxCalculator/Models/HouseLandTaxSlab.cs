﻿using System;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "करको प्रतिसत")]
        public decimal TaxPercent { get; set; }

        
        [Display(Name = "बक्यौता करको रकम")]
        public decimal LastFYTaxAmount { get; set; }

        
        [Display(Name = "बक्यौता करको प्रतिसत")]
        public decimal LastFYTaxPercent { get; set; }

        [Required]
        [Display(Name = "Range")]
        public decimal Range { get; set; }

        public Boolean FirstSlab { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public String FiscalYear { get; set; }

    }
}