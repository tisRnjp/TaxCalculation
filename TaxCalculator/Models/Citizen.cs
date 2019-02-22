using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaxCalculator.Models
{
    public class Citizen
    {
        [Key]
        public int CitizenId { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Last Name")]
        public string  LastName { get; set; }

        public string Zone { get; set; }

        public string District { get; set; }

        [Display(Name = "Street Name")]
        public string StreetName { get; set; }

        [Display(Name = "Ward No")]
        public int Wardno { get; set; }

        public string Municipality { get; set; }

        public ICollection<CitizenProperty> CitizenProperties { get; set; }

    }
}