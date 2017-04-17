namespace VehicleAppMVC.Migrations.ApplicationDbMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update5 : DbMigration
    {
        public override void Up()
        {
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
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        VehicleMake = c.String(nullable: false),
                        VehicleModel = c.String(nullable: false),
                        VehicleRegistrationNumber = c.String(nullable: false),
                        VehicleOdometerMileage = c.Int(nullable: false),
                        SettingFuelType = c.Int(nullable: false),
                        SettingDistance = c.Int(nullable: false),
                        SettingVolume = c.Int(nullable: false),
                        SettingConsumption = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "UserID", "dbo.Users");
            DropForeignKey("dbo.Fuels", "VehicleID", "dbo.Vehicles");
            DropForeignKey("dbo.Costs", "VehicleID", "dbo.Vehicles");
            DropForeignKey("dbo.Notifications", "UserID", "dbo.Users");
            DropIndex("dbo.Fuels", new[] { "VehicleID" });
            DropIndex("dbo.Costs", new[] { "VehicleID" });
            DropIndex("dbo.Vehicles", new[] { "UserID" });
            DropIndex("dbo.Notifications", new[] { "UserID" });
            DropTable("dbo.Fuels");
            DropTable("dbo.Costs");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Notifications");
        }
    }
}
