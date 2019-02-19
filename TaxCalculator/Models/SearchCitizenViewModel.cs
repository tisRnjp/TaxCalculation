using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxCalculator.Models
{
    public class SearchCitizenViewModel
    {
        public int citizenID { get; set; }
        public List<Citizen> Citizens { get; set; }


    }
}