using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaxCalculator.Models
{

    public class Citizen
    {
        [Key]
        public int CitizenId { get; set; }
        
        [MaxLength(20)]
        [Display(Name = "नागरिकता नम्बर")]
        //[Required(ErrorMessage = "नागरिकता नम्बर अनिवार्य छ।")]
        public string CitizenshipNo { get; set; }

        
        [MaxLength(255)]
        //[Required(ErrorMessage = "नाम अनिवार्य छ।")]
        [Display(Name = "नाम ")]
        public string FirstName { get; set; }
        
        //[Required(ErrorMessage = "थर अनिवार्य छ।")]
        [MaxLength(255)]
        [Display(Name = "थर")]
        public string  LastName { get; set; }

        //[Required(ErrorMessage = "जिल्ला अनिवार्य छ।")]
        [Display(Name = "जिल्ला")]
        public string District { get; set; }
        
        //[Required(ErrorMessage = "ठेगाना अनिवार्य छ।")]
        [Display(Name = "ठेगाना")]
        public string StreetName { get; set; }

        //[Required(ErrorMessage = "वडा न. अनिवार्य छ।")]
        [Display(Name = "वडा न.")]
        public int Wardno { get; set; }

        //[Required(ErrorMessage = "test")]
        [Display(Name = "कित्ता नम्बर")]
        public string KittaNo { get; set; }
        
        //[Required(ErrorMessage = "नगरपालिका अनिवार्य छ।")]
        [Display(Name = "नगरपालिका")]
        public string Municipality { get; set; }

        [Display(Name = "अञ्चल")] 
        public int? ZoneId { get; set; }

        //[Required(ErrorMessage = "अञ्चल अनिवार्य छ।")]
        [Display(Name = "अञ्चल")]
        //[DisplayFormat(NullDisplayText = "", ApplyFormatInEditMode = true)]
        public Zone Zone { get; set; }

        public ICollection<CitizenHouse> CitizenHouses { get; set; }
        public ICollection<CitizenLand> CitizenLands { get; set; }

        public ICollection<CitizenProperty> CitizenProperties { get; set; }

    }
}