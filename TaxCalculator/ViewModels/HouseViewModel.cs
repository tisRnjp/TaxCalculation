using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaxCalculator.Models;

namespace TaxCalculator.ViewModels
{
    public class HouseViewModel
    {
        public IEnumerable<CitizenHouse> CitizenHouses { get; set; }
    }
}