using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaxCalculator.Models
{
    public class HouseTaxHistory
    {
        public int Id { get; set; }

        [Display(Name = "प्रति वर्ग फु दर")]
        [Required(ErrorMessage = "प्रति वर्ग फु दर अनिवार्य छ।")]
        public decimal CostPerUnitArea { get; set; }

        //[Required]
        [Display(Name = "वर्ग फु")]
        public decimal TotalArea { get; set; }

        [Required(ErrorMessage = "घरको बनावट अनिवार्य छ।")]
        public string HouseCategory { get; set; }

        [Required(ErrorMessage = "कायमी मुल्य गणना गर्न सकिएन।")]
        [Display(Name = "कायमी मुल्य")]
        public decimal TotalCost { get; set; }

        [Required(ErrorMessage = "चालु आ व को कायम मूल्य गणना गर्न सकिएन।")]
        [Display(Name = "चालु आ व को कायम मूल्य")]
        public decimal GrossCost { get; set; }
        
        [Required(ErrorMessage = "ह्रासकट्टी प्रतिशत अनिवार्य छ।")]
        [Display(Name = "ह्रासकट्टी प्रतिशत")]
        [Range(1, 100.00, ErrorMessage = "ह्रासकट्टी प्रतिशत गलत भयो।")]
        [RegularExpression(@"((\d+)+(\.\d+))$", ErrorMessage = "ह्रासकट्टी प्रतिशत गलत भयो।")]
        [DataType(DataType.Currency, ErrorMessage = "ह्रासकट्टी प्रतिशत गलत भयो।")]
        public decimal DepreciationRate { get; set; }

        [Required(ErrorMessage = "ह्रासकट्टी रकम गणना गर्न सकिएन।")]
        [Display(Name = "ह्रासकट्टी रकम")]
        public decimal DepreciationAmount { get; set; }

        [Display(Name = "गत आ व को कायम मूल्य")]
        public decimal? LastFYGrossCost { get; set; }

        [Display(Name = "गत वर्ष सम्म को ह्रासकट्टी प्रतिशत")]
        [Range(1, 100.00, ErrorMessage = "ह्रासकट्टी प्रतिशत गलत भयो।")]
        [RegularExpression(@"((\d+)+(\.\d+))$", ErrorMessage = "ह्रासकट्टी प्रतिशत गलत भयो।")]
        [DataType(DataType.Currency, ErrorMessage = "ह्रासकट्टी प्रतिशत गलत भयो।")]
        public decimal? LastFYDepreciationRate { get; set; }

        [Display(Name = "गत वर्ष सम्म को ह्रासकट्टी प्रतिशत")]
        public decimal? LastFYDepreciationAmount { get; set; }

        //public int? CitizenId { get; set; }
        //public Citizen Citizen { get; set; }

        public int? CitizenHouseId{ get; set; }
        public CitizenHouse CitizenHouse { get; set; }

        [Display(Name = "आ व देखि")]
        public string FromFY { get; set; }

        [Display(Name = "आ व सम्म")]
        public string ToFY { get; set; }

        [Display(Name = "आ व देखि")]
        public int? TotalYears { get; set; }

        [Display(Name = "आ व देखि")]
        //[Required(ErrorMessage = "आ व अनिवार्य छ।")]
        public int? FromFiscalYearId { get; set; }
        [Display(Name = "आ व देखि")]
        public FiscalYear FromFiscalYear { get; set; }



        [Display(Name = "आ व सम्म")]
        //[Required(ErrorMessage = "आ व अनिवार्य छ।")]
        public int? ToFiscalYearId { get; set; }
        [Display(Name = "आ व देखि")]
        [Required(ErrorMessage = "आ व गणना गर्न सकिएन।")]
        public FiscalYear ToFiscalYear { get; set; }
    }
}