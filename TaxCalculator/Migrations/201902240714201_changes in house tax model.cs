namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesinhousetaxmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HouseTaxHistory", "CitizenId", "dbo.Citizen");
            DropIndex("dbo.HouseTaxHistory", new[] { "CitizenId" });
            RenameColumn(table: "dbo.HouseTaxViewModel", name: "houseTaxHistory_Id", newName: "LastHouseTax_Id");
            RenameIndex(table: "dbo.HouseTaxViewModel", name: "IX_houseTaxHistory_Id", newName: "IX_LastHouseTax_Id");
            AddColumn("dbo.HouseTaxHistory", "CostPerUnitArea", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.CitizenHouse", "BatoKoPrakar");
            DropColumn("dbo.HouseTaxHistory", "CurrentCost");
            DropColumn("dbo.HouseTaxHistory", "LastYearCost");
            DropColumn("dbo.HouseTaxHistory", "CitizenId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HouseTaxHistory", "CitizenId", c => c.Int());
            AddColumn("dbo.HouseTaxHistory", "LastYearCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.HouseTaxHistory", "CurrentCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.CitizenHouse", "BatoKoPrakar", c => c.String());
            DropColumn("dbo.HouseTaxHistory", "CostPerUnitArea");
            RenameIndex(table: "dbo.HouseTaxViewModel", name: "IX_LastHouseTax_Id", newName: "IX_houseTaxHistory_Id");
            RenameColumn(table: "dbo.HouseTaxViewModel", name: "LastHouseTax_Id", newName: "houseTaxHistory_Id");
            CreateIndex("dbo.HouseTaxHistory", "CitizenId");
            AddForeignKey("dbo.HouseTaxHistory", "CitizenId", "dbo.Citizen", "CitizenId");
        }
    }
}
