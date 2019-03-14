namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fiscalyearstringsaddedtohousetaxhistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HouseTaxHistory", "FromFY", c => c.String());
            AddColumn("dbo.HouseTaxHistory", "ToFY", c => c.String());
            AddColumn("dbo.LandTaxHistory", "FromFY", c => c.String());
            AddColumn("dbo.LandTaxHistory", "ToFY", c => c.String());
            DropColumn("dbo.LandTaxHistory", "FY");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LandTaxHistory", "FY", c => c.String());
            DropColumn("dbo.LandTaxHistory", "ToFY");
            DropColumn("dbo.LandTaxHistory", "FromFY");
            DropColumn("dbo.HouseTaxHistory", "ToFY");
            DropColumn("dbo.HouseTaxHistory", "FromFY");
        }
    }
}
