namespace VehicleAppMVC.Migrations.ApplicationDbMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "UserMobileNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserMobileNumber", c => c.String());
        }
    }
}
