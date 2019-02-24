namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedgetfromhousetaxmodelfields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HouseTaxHistory", "TotalCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.HouseTaxHistory", "GrossCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.HouseTaxHistory", "DepreciationAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HouseTaxHistory", "DepreciationAmount");
            DropColumn("dbo.HouseTaxHistory", "GrossCost");
            DropColumn("dbo.HouseTaxHistory", "TotalCost");
        }
    }
}
