using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaxCalculator.Models;

namespace TaxCalculator.ViewModels
{
    public class LandFormViewModel
    {
        public IEnumerable<Citizen> Citizens { get; set; }
        public CitizenLand CitizenLand { get; set; }
    }
}