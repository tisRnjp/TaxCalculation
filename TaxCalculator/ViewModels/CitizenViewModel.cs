using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaxCalculator.Models;

namespace TaxCalculator.ViewModels
{
    public class CitizenViewModel
    {
        public  Citizen Citizen { get; set; }
        public CitizenHouse CitizenHouse { get; set; }
        public CitizenLand CitizenLand { get; set; }
        

        public IEnumerable<Zone> Zones { get; set; }

    }
}