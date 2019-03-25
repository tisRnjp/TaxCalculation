using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaxCalculator.DTOS
{
    public class CitizenHouseDto
    {
        public int Id { get; set; }

        public decimal Length { get; set; }

        public decimal Width { get; set; }

        [Required(ErrorMessage = "वर्ग फूट अनिवार्य छ।")]
        public decimal Area { get; set; }
        
        public decimal Floor { get; set; }

        public string Image { get; set; }

        public int? CitizenId { get; set; }
    }
}