using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxCalculator.Models
{
    public class CitizenHouse
    {
        public int Id { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Area { get; set; }
        public decimal Floor { get; set; }



        public int? CitizenId { get; set; }
        public Citizen citizen { get; set; }
    }
    public class CitizenLand
    {
        public int Id { get; set; }
        public string VDC { get; set; }
        public string WardNo { get; set; }
        public string SheetNo { get; set; }
        public string KittaNo { get; set; }
        public decimal ValuationArea { get; set; }
        



        public int? CitizenId { get; set; }
        public Citizen citizen { get; set; }
    }
}