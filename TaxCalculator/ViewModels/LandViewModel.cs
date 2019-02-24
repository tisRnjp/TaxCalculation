using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaxCalculator.Models;

namespace TaxCalculator.ViewModels
{
    public class LandViewModel
    {
        public IEnumerable<CitizenLand> CitizenLands { get; set; }
    }
}