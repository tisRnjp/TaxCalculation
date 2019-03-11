namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastfiscalyearfieldaddedtohousvaluationandtaxslab : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HouseLandTaxSlab", "LastFYTaxAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.HouseLandTaxSlab", "LastFYTaxPercent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.HouseValuation", "LastFYCostPerArea", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.HouseValuation", "LastFYDepreciationRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.HouseValuation", "LastFYDepreciationPeriod", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HouseValuation", "LastFYDepreciationPeriod");
            DropColumn("dbo.HouseValuation", "LastFYDepreciationRate");
            DropColumn("dbo.HouseValuation", "LastFYCostPerArea");
            DropColumn("dbo.HouseLandTaxSlab", "LastFYTaxPercent");
            DropColumn("dbo.HouseLandTaxSlab", "LastFYTaxAmount");
        }
    }
}
