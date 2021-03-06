﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaxCalculator.Models
{

    public class Citizen
    {
        [Key]
        public int CitizenId { get; set; }

        
        [MaxLength(20)]

        [Display(Name = "नागरिकता नम्बर")]
        //[Index(nameof(CitizenshipNo),IsUnique = true)]
        public string CitizenshipNo { get; set; }

        
        [MaxLength(255)]
        [Required(ErrorMessage = "Please enter the First Name!")]
        [Display(Name = "नाम ")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter the Last Name!")]
        [MaxLength(255)]
        [Display(Name = "थर")]
        public string  LastName { get; set; }

        //public string Zone { get; set; }
        [Display(Name = "जिल्ला")]
        public string District { get; set; }

        
        [Display(Name = "ठेगाना")]
        public string StreetName { get; set; }

        [Display(Name = "वडा न.")]
        public int Wardno { get; set; }

        [Display(Name = "कित्ता नम्बर")]
        public string KittaNo { get; set; }


        [Display(Name = "नगरपालिका")]
        public string Municipality { get; set; }
        
        [Display(Name = "अञ्चल")] 
        public int? ZoneId { get; set; }
        [Display(Name = "अञ्चल")]
        [DisplayFormat(NullDisplayText = "", ApplyFormatInEditMode = true)]
        public Zone Zone { get; set; }

        public ICollection<CitizenHouse> CitizenHouses { get; set; }
        public ICollection<CitizenLand> CitizenLands { get; set; }

        public ICollection<CitizenProperty> CitizenProperties { get; set; }

    }
}