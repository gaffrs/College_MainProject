namespace VehicleAppMVC.Migrations.VehicleAppMVCMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Costs",
                c => new
                    {
                        CostID = c.Int(nullable: false, identity: true),
                        VehicleID = c.Int(nullable: false),
                        CostDate = c.DateTime(nullable: false),
                        CostOdometerMileage = c.Int(nullable: false),
                        CostTitle = c.Int(nullable: false),
                        CostRunningCost = c.Double(nullable: false),
                        CostStartDate = c.DateTime(nullable: false),
                        CostEndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CostID)
                .ForeignKey("dbo.Vehicles", t => t.VehicleID, cascadeDelete: true)
                .Index(t => t.VehicleID);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        VehicleMake = c.String(nullable: false),
                        VehicleModel = c.String(nullable: false),
                        VehicleRegistrationNumber = c.String(nullable: false),
                        VehicleOdometerMileage = c.Int(nullable: false),
                        SettingFuelType = c.Int(nullable: false),
                        SettingDistance = c.Int(nullable: false),
                        SettingVolume = c.Int(nullable: false),
                        SettingConsumption = c.Int(nullable: false),
                        Users_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.VehicleID)
                .ForeignKey("dbo.Users", t => t.Users_UserID)
                .Index(t => t.Users_UserID);
            
            CreateTable(
                "dbo.Fuels",
                c => new
                    {
                        FuelID = c.Int(nullable: false, identity: true),
                        VehicleID = c.Int(nullable: false),
                        FuelDate = c.DateTime(nullable: false),
                        FuelOdometerMileage = c.Int(nullable: false),
                        FuelQuantity = c.Int(nullable: false),
                        FuelUnitPrice = c.Double(nullable: false),
                        FuelPartialFill = c.Boolean(nullable: false),
                        FuelConsumption = c.Double(nullable: false),
                        FuelCost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.FuelID)
                .ForeignKey("dbo.Vehicles", t => t.VehicleID, cascadeDelete: true)
                .Index(t => t.VehicleID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        NotificationDate = c.DateTime(nullable: false),
                        NotificationSendDate = c.DateTime(nullable: false),
                        NotificationType = c.Int(nullable: false),
                        NotificationTitle = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NotificationID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "Users_UserID", "dbo.Users");
            DropForeignKey("dbo.Notifications", "UserID", "dbo.Users");
            DropForeignKey("dbo.Fuels", "VehicleID", "dbo.Vehicles");
            DropForeignKey("dbo.Costs", "VehicleID", "dbo.Vehicles");
            DropIndex("dbo.Notifications", new[] { "UserID" });
            DropIndex("dbo.Fuels", new[] { "VehicleID" });
            DropIndex("dbo.Vehicles", new[] { "Users_UserID" });
            DropIndex("dbo.Costs", new[] { "VehicleID" });
            DropTable("dbo.Notifications");
            DropTable("dbo.Users");
            DropTable("dbo.Fuels");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Costs");
        }
    }
}
