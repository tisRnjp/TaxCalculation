using System.ComponentModel.DataAnnotations;

namespace TaxCalculator.Models
{
    public class CitizenLand
    {
        public int Id { get; set; }

        [Display(Name = "गा वि स")]
        public string VDC { get; set; }

        [Display(Name = "वदा नम्बर")]
        public string WardNo { get; set; }

        [Display(Name = "शीट नम्बर")]
        public string SheetNo { get; set; }

        [Display(Name = "कित्ता नम्बर")]
        public string KittaNo { get; set; }

        [Display(Name = "मुल्यांकन हुने क्ष फ")]
        public decimal ValuationArea { get; set; }



        [Display(Name = "नागरिकता नम्बर")]
        public int? CitizenId { get; set; }

        public Citizen citizen { get; set; }
    }
}