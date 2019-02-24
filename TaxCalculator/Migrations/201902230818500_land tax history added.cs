namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class landtaxhistoryadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LandTaxHistory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FY = c.String(),
                        MyProperty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValuationArea = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostPerUnitArea = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LandId = c.Int(),
                        CitizenLand_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CitizenLand", t => t.CitizenLand_Id)
                .Index(t => t.CitizenLand_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LandTaxHistory", "CitizenLand_Id", "dbo.CitizenLand");
            DropIndex("dbo.LandTaxHistory", new[] { "CitizenLand_Id" });
            DropTable("dbo.LandTaxHistory");
        }
    }
}
