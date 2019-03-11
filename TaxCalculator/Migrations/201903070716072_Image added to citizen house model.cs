namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Imageaddedtocitizenhousemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CitizenHouse", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CitizenHouse", "Image");
        }
    }
}
