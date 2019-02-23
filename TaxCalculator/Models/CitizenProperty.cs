namespace TaxCalculator.Models
{
    public class CitizenProperty
    {
        public int CitizenPropertyId { get; set; }

        public string PropertyType { get; set; }

        public double PropertyArea { get; set; }

        public int CitizenId { get; set; }
        public Citizen Citizen { get; set; }
    }
}