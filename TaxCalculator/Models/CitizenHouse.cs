using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxCalculator.Models
{
    public class CitizenHouse
    {
        public int Id { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Area { get; set; }
        public decimal Floor { get; set; }



        public int? CitizenId { get; set; }
        public Citizen citizen { get; set; }
    }
}