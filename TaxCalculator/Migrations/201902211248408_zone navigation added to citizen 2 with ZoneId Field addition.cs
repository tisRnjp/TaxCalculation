namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zonenavigationaddedtocitizen2withZoneIdFieldaddition : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Citizen", name: "Zone_Id", newName: "ZoneId");
            RenameIndex(table: "dbo.Citizen", name: "IX_Zone_Id", newName: "IX_ZoneId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Citizen", name: "IX_ZoneId", newName: "IX_Zone_Id");
            RenameColumn(table: "dbo.Citizen", name: "ZoneId", newName: "Zone_Id");
        }
    }
}
