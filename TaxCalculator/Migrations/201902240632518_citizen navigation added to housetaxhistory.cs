namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class citizennavigationaddedtohousetaxhistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HouseTaxHistory", "CitizenId", c => c.Int());
            CreateIndex("dbo.HouseTaxHistory", "CitizenId");
            AddForeignKey("dbo.HouseTaxHistory", "CitizenId", "dbo.Citizen", "CitizenId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HouseTaxHistory", "CitizenId", "dbo.Citizen");
            DropIndex("dbo.HouseTaxHistory", new[] { "CitizenId" });
            DropColumn("dbo.HouseTaxHistory", "CitizenId");
        }
    }
}
