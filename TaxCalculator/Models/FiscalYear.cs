using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaxCalculator.Models
{
    public class FiscalYear
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Sequence { get; set; }

        [MaxLength(10)]
        [Required]
        public string FY { get; set; }

    }
}