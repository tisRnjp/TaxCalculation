namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class annotationaddedtocitizenland : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CitizenLand", "VDC", c => c.String(nullable: false));
            AlterColumn("dbo.CitizenLand", "WardNo", c => c.String(nullable: false));
            AlterColumn("dbo.CitizenLand", "SheetNo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CitizenLand", "SheetNo", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.CitizenLand", "WardNo", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.CitizenLand", "VDC", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
