using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaxCalculator.Models;

namespace TaxCalculator.ViewModels
{
    public class HouseFormViewModel
    {
        public IEnumerable<Citizen> Citizens { get; set; }
        public CitizenHouse CitizenHouse { get; set; }
    }
}