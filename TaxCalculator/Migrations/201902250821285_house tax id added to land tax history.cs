namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class housetaxidaddedtolandtaxhistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LandTaxHistory", "HouseTaxHistoryId", c => c.Int());
            CreateIndex("dbo.LandTaxHistory", "HouseTaxHistoryId");
            AddForeignKey("dbo.LandTaxHistory", "HouseTaxHistoryId", "dbo.HouseTaxHistory", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LandTaxHistory", "HouseTaxHistoryId", "dbo.HouseTaxHistory");
            DropIndex("dbo.LandTaxHistory", new[] { "HouseTaxHistoryId" });
            DropColumn("dbo.LandTaxHistory", "HouseTaxHistoryId");
        }
    }
}
