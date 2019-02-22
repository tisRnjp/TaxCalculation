using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaxCalculator.Models
{

    public class Citizen
    {
        [Key]
        public int CitizenId { get; set; }

        
        [MaxLength(20)]
        //[Index(nameof(CitizenshipNo),IsUnique = true)]
        public string CitizenshipNo { get; set; }

        
        [MaxLength(255)]
        [Display(Name = "नागरिक को नाम ")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter the Last Name!")]
        [MaxLength(255)]
        [Display(Name = "Last Name")]
        public string  LastName { get; set; }

        //public string Zone { get; set; }

        public string District { get; set; }

        [Display(Name = "Street Name")]
        public string StreetName { get; set; }

        [Display(Name = "Ward No")]
        public int Wardno { get; set; }

        public string Municipality { get; set; }





        public int? ZoneId { get; set; }
        public Zone Zone { get; set; }

        public ICollection<CitizenHouse> CitizenHouses { get; set; }
        public ICollection<CitizenLand> CitizenLands { get; set; }

        public ICollection<CitizenProperty> CitizenProperties { get; set; }

    }
}