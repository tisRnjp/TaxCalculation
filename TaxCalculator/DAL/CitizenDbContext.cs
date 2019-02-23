﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TaxCalculator.Models;

namespace TaxCalculator.DAL
{
    public class CitizenDbContext : DbContext
    {
        public CitizenDbContext() : base("CitizenDbContext")
        {

        }

        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<CitizenProperty> CitizenProperties { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<CitizenLand> CitizenLands { get; set; }
        public DbSet<CitizenHouse> CitizenHouses { get; set; }
        public DbSet<PropertyType> PropertyType { get; set; }
        public DbSet<HouseTaxHistory> HouseTaxHistories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<Citizen>()
            //            .HasOptional(c => c.Zone)
            //            .WithRequired

        }

        public System.Data.Entity.DbSet<TaxCalculator.Models.HouseTaxViewModel> HouseTaxViewModels { get; set; }
    }
}