namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unknownchanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HouseTaxViewModel", "CitizenHouse_Id", "dbo.CitizenHouse");
            DropForeignKey("dbo.HouseTaxViewModel", "HouseTax_Id", "dbo.HouseTaxHistory");
            DropForeignKey("dbo.HouseTaxViewModel", "LastHouseTax_Id", "dbo.HouseTaxHistory");
            DropIndex("dbo.HouseTaxViewModel", new[] { "CitizenHouse_Id" });
            DropIndex("dbo.HouseTaxViewModel", new[] { "HouseTax_Id" });
            DropIndex("dbo.HouseTaxViewModel", new[] { "LastHouseTax_Id" });
            DropTable("dbo.HouseTaxViewModel");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.HouseTaxViewModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CitizenHouse_Id = c.Int(),
                        HouseTax_Id = c.Int(),
                        LastHouseTax_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.HouseTaxViewModel", "LastHouseTax_Id");
            CreateIndex("dbo.HouseTaxViewModel", "HouseTax_Id");
            CreateIndex("dbo.HouseTaxViewModel", "CitizenHouse_Id");
            AddForeignKey("dbo.HouseTaxViewModel", "LastHouseTax_Id", "dbo.HouseTaxHistory", "Id");
            AddForeignKey("dbo.HouseTaxViewModel", "HouseTax_Id", "dbo.HouseTaxHistory", "Id");
            AddForeignKey("dbo.HouseTaxViewModel", "CitizenHouse_Id", "dbo.CitizenHouse", "Id");
        }
    }
}
