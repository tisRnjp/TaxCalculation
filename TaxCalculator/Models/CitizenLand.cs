namespace TaxCalculator.Models
{
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