namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zoneidaddedtocitizen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Citizen", "ZoneId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Citizen", "ZoneId");
        }
    }
}
