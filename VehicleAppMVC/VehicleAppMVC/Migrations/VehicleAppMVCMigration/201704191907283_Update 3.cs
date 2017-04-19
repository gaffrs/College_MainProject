namespace VehicleAppMVC.Migrations.VehicleAppMVCMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vehicles", "Users_UserID", "dbo.Users");
            DropIndex("dbo.Vehicles", new[] { "Users_UserID" });
            RenameColumn(table: "dbo.Vehicles", name: "Users_UserID", newName: "UserID");
            AlterColumn("dbo.Vehicles", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Vehicles", "UserID");
            AddForeignKey("dbo.Vehicles", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
            DropColumn("dbo.Vehicles", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "Email", c => c.String());
            DropForeignKey("dbo.Vehicles", "UserID", "dbo.Users");
            DropIndex("dbo.Vehicles", new[] { "UserID" });
            AlterColumn("dbo.Vehicles", "UserID", c => c.Int());
            RenameColumn(table: "dbo.Vehicles", name: "UserID", newName: "Users_UserID");
            CreateIndex("dbo.Vehicles", "Users_UserID");
            AddForeignKey("dbo.Vehicles", "Users_UserID", "dbo.Users", "UserID");
        }
    }
}
