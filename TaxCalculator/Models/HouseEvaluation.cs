using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaxCalculator.Models
{
    public class HouseEvaluation
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "विघर को बनावट")]
        public string Description{ get; set; }

        [Required]
        [Display(Name = "विऔसत लागत दर प्रति वर्ग फूट (रु)")]
        public decimal CostPerArea { get; set; }

        [Required]
        [Display(Name = "ह्रासकति (प्रतिसत)")]
        public decimal DepreciationRate { get; set; }

        [Required]
        [Display(Name = "वकत्ति गर्ने जम्मा वर्ष")]
        public decimal DepreciationPeriod { get; set; }
    }
}