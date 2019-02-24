namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changetheforeignkeyoflandtaxhistory : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.LandTaxHistory", name: "CitizenLand_Id", newName: "CitizenLandId");
            RenameIndex(table: "dbo.LandTaxHistory", name: "IX_CitizenLand_Id", newName: "IX_CitizenLandId");
            DropColumn("dbo.LandTaxHistory", "LandId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LandTaxHistory", "LandId", c => c.Int());
            RenameIndex(table: "dbo.LandTaxHistory", name: "IX_CitizenLandId", newName: "IX_CitizenLand_Id");
            RenameColumn(table: "dbo.LandTaxHistory", name: "CitizenLandId", newName: "CitizenLand_Id");
        }
    }
}
