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

        


        public int CitizenId { get; set; }
        public Citizen citizen { get; set; }
    }
    public class CitizenLand
    {
        public int Id { get; set; }



        public int CitizenId { get; set; }
        public Citizen citizen { get; set; }
    }
}