using System.ComponentModel.DataAnnotations;

namespace TaxCalculator.Models
{
    public class CitizenLand
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "गा वि स अनिवार्य छ।")]
        [Display(Name = "गा वि स")]
        public string VDC { get; set; }

        [Required(ErrorMessage = "वडा नम्बर अनिवार्य छ।")]
        [Display(Name = "वडा नम्बर")]
        public string WardNo { get; set; }

        [Required(ErrorMessage = "शीट नम्बर अनिवार्य छ।")]
        [Display(Name = "शीट नम्बर")]
        public string SheetNo { get; set; }

        [Required(ErrorMessage = "कित्ता नम्बर अनिवार्य छ।")]
        [Display(Name = "कित्ता नम्बर")]
        public string KittaNo { get; set; }

        [Required(ErrorMessage = "मुल्यांकन हुने क्ष फ अनिवार्य छ।")]
        [Display(Name = "मुल्यांकन हुने क्ष फ")]
        public decimal ValuationArea { get; set; }

        [Required(ErrorMessage = "नागरिकता नम्बर अनिवार्य छ।")]
        [Display(Name = "नागरिकता नम्बर")]
        public int? CitizenId { get; set; }

        public Citizen citizen { get; set; }
    }
}