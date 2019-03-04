namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedfieldsinHouseLandTaxSlab : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HouseLandTaxSlab", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.HouseLandTaxSlab", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.HouseLandTaxSlab", "FiscalYear", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HouseLandTaxSlab", "FiscalYear");
            DropColumn("dbo.HouseLandTaxSlab", "EndDate");
            DropColumn("dbo.HouseLandTaxSlab", "StartDate");
        }
    }
}
