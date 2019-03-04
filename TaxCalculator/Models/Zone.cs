using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaxCalculator.Models
{
    public class Zone
    {
        public int Id { get; set; }

        [Display(Name = "अञ्चल न.")]
        public string Code { get; set; }

        [Display(Name = "अञ्चल")]
        [DisplayFormat(NullDisplayText = "", ApplyFormatInEditMode = true)]
        public string Description { get; set; }

        public ICollection<Citizen> Citizens { get; set; }

    }
}