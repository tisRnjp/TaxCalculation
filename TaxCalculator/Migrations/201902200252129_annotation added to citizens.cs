namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class annotationaddedtocitizens : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Citizen", "FirstName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Citizen", "LastName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Citizen", "LastName", c => c.String());
            AlterColumn("dbo.Citizen", "FirstName", c => c.String());
        }
    }
}
