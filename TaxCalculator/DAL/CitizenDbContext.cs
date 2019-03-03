using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TaxCalculator.Models;

namespace TaxCalculator.DAL
{
    public class CitizenDbContext : DbContext
    {
        public CitizenDbContext() : base("CitizenDbContext")
        {
            this.Configuration.LazyLoadingEnabled = false;

        }

        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<CitizenProperty> CitizenProperties { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<CitizenLand> CitizenLands { get; set; }
        public DbSet<CitizenHouse> CitizenHouses { get; set; }
        public DbSet<LandTaxHistory> LandTaxHistories { get; set; }
        public DbSet<HouseTaxHistory> HouseTaxHistories { get; set; }
        public DbSet<HouseValuation> HouseValuations { get; set; }
        public DbSet<LandValuation> LandValuations { get; set; }
        public DbSet<HouseLandTaxSlab> HouseLandTaxSlabs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }

        
    }
}