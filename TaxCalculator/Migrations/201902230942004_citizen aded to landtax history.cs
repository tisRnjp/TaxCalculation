namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class citizenadedtolandtaxhistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LandTaxHistory", "CitizenId", c => c.Int());
            CreateIndex("dbo.LandTaxHistory", "CitizenId");
            AddForeignKey("dbo.LandTaxHistory", "CitizenId", "dbo.Citizen", "CitizenId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LandTaxHistory", "CitizenId", "dbo.Citizen");
            DropIndex("dbo.LandTaxHistory", new[] { "CitizenId" });
            DropColumn("dbo.LandTaxHistory", "CitizenId");
        }
    }
}
