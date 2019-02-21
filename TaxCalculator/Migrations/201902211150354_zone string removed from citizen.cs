namespace TaxCalculator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zonestringremovedfromcitizen : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Zone",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Citizen", "Zone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Citizen", "Zone", c => c.String());
            DropTable("dbo.Zone");
        }
    }
}
