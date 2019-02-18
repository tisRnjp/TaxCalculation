using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaxCalculator.Models
{
    public class Citizen
    {
        [Key]
        public int CitizenId { get; set; }

        public string FirstName { get; set; }

        public string  LastName { get; set; }

        public string Zone { get; set; }

        public string District { get; set; }

        public string StreetName { get; set; }

        public int Wardno { get; set; }

        public string Municipality { get; set; }

        public ICollection<CitizenProperty> CitizenProperties { get; set; }

    }
}