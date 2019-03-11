using System.ComponentModel.DataAnnotations;

namespace TaxCalculator.Models
{
    public class LandValuation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "जग्गा को किसिम")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "जग्गा को प्रकार")]
        public string LandType { get; set; }

        [Required]
        [Display(Name = "प्रति आना को दर")]
        public decimal CostPerAnna { get; set; }


        
        public int? FiscalYearId { get; set; }
        public FiscalYear FiscalYear { get; set; }

    }
}