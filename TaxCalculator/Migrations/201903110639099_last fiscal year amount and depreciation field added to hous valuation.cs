namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastfiscalyearamountanddepreciationfieldaddedtohousvaluation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HouseTaxHistory", "LastFYGrossCost", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.HouseTaxHistory", "LastFYDepreciationRate", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.HouseTaxHistory", "LastFYDepreciationAmount", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HouseTaxHistory", "LastFYDepreciationAmount");
            DropColumn("dbo.HouseTaxHistory", "LastFYDepreciationRate");
            DropColumn("dbo.HouseTaxHistory", "LastFYGrossCost");
        }
    }
}
