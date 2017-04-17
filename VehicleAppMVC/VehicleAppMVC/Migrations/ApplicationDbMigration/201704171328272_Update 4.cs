namespace VehicleAppMVC.Migrations.ApplicationDbMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        ID = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.AspNetUsers", "UserMobileNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Users", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "UserMobileNumber");
            DropTable("dbo.Users");
        }
    }
}
