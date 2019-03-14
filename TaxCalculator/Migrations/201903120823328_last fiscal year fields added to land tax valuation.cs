namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastfiscalyearfieldsaddedtolandtaxvaluation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LandTaxHistory", "LastFYCostPerUnitArea", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.LandTaxHistory", "LastFYTotalCost", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LandTaxHistory", "LastFYTotalCost");
            DropColumn("dbo.LandTaxHistory", "LastFYCostPerUnitArea");
        }
    }
}
