using System.ComponentModel.DataAnnotations;

namespace TaxCalculator.Models
{
    public class CitizenLand
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="VDC is required to proceed.")]
        [Display(Name = "गा वि स")]
        public string VDC { get; set; }

        [Required]
        [Display(Name = "वदा नम्बर")]
        public string WardNo { get; set; }

        [Required]
        [Display(Name = "शीट नम्बर")]
        public string SheetNo { get; set; }

        [Required]
        [Display(Name = "कित्ता नम्बर")]
        public string KittaNo { get; set; }

        [Required]
        [Display(Name = "मुल्यांकन हुने क्ष फ")]
        public decimal ValuationArea { get; set; }

        [Required]
        [Display(Name = "नागरिकता नम्बर")]
        public int? CitizenId { get; set; }

        public Citizen citizen { get; set; }
    }
}