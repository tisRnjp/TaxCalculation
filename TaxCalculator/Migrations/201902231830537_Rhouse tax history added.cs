namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rhousetaxhistoryadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HouseTaxHistory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrentCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LastYearCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DepreciationRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CitizenHouseId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CitizenHouse", t => t.CitizenHouseId)
                .Index(t => t.CitizenHouseId);
            
            AddColumn("dbo.HouseTaxViewModel", "HouseTax_Id", c => c.Int());
            AddColumn("dbo.HouseTaxViewModel", "houseTaxHistory_Id", c => c.Int());
            CreateIndex("dbo.HouseTaxViewModel", "HouseTax_Id");
            CreateIndex("dbo.HouseTaxViewModel", "houseTaxHistory_Id");
            AddForeignKey("dbo.HouseTaxViewModel", "HouseTax_Id", "dbo.HouseTaxHistory", "Id");
            AddForeignKey("dbo.HouseTaxViewModel", "houseTaxHistory_Id", "dbo.HouseTaxHistory", "Id");
            DropColumn("dbo.HouseTaxViewModel", "CurrentCost");
            DropColumn("dbo.HouseTaxViewModel", "LastYearCost");
            DropColumn("dbo.HouseTaxViewModel", "DepreciationRate");
            DropColumn("dbo.HouseTaxViewModel", "DepreciationRateLastYear");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HouseTaxViewModel", "DepreciationRateLastYear", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.HouseTaxViewModel", "DepreciationRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.HouseTaxViewModel", "LastYearCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.HouseTaxViewModel", "CurrentCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.HouseTaxViewModel", "houseTaxHistory_Id", "dbo.HouseTaxHistory");
            DropForeignKey("dbo.HouseTaxViewModel", "HouseTax_Id", "dbo.HouseTaxHistory");
            DropForeignKey("dbo.HouseTaxHistory", "CitizenHouseId", "dbo.CitizenHouse");
            DropIndex("dbo.HouseTaxViewModel", new[] { "houseTaxHistory_Id" });
            DropIndex("dbo.HouseTaxViewModel", new[] { "HouseTax_Id" });
            DropIndex("dbo.HouseTaxHistory", new[] { "CitizenHouseId" });
            DropColumn("dbo.HouseTaxViewModel", "houseTaxHistory_Id");
            DropColumn("dbo.HouseTaxViewModel", "HouseTax_Id");
            DropTable("dbo.HouseTaxHistory");
        }
    }
}
