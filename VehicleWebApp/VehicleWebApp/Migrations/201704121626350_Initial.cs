namespace VehicleWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cost",
                c => new
                    {
                        CostID = c.Int(nullable: false, identity: true),
                        VehicleID = c.Int(nullable: false),
                        CostDate = c.DateTime(nullable: false),
                        CostOdometerMileage = c.Int(nullable: false),
                        CostTitle = c.Int(nullable: false),
                        CostStartDate = c.DateTime(nullable: false),
                        CostEndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CostID)
                .ForeignKey("dbo.Vehicle", t => t.VehicleID, cascadeDelete: true)
                .Index(t => t.VehicleID);
            
            CreateTable(
                "dbo.Vehicle",
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
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Fuel",
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
                .ForeignKey("dbo.Vehicle", t => t.VehicleID, cascadeDelete: true)
                .Index(t => t.VehicleID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        UserPassword = c.String(nullable: false),
                        UserEmailAddress = c.String(nullable: false),
                        UserMobileNumber = c.String(nullable: false, maxLength: 10),
                        UserType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Notification",
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
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicle", "UserID", "dbo.User");
            DropForeignKey("dbo.Notification", "UserID", "dbo.User");
            DropForeignKey("dbo.Fuel", "VehicleID", "dbo.Vehicle");
            DropForeignKey("dbo.Cost", "VehicleID", "dbo.Vehicle");
            DropIndex("dbo.Notification", new[] { "UserID" });
            DropIndex("dbo.Fuel", new[] { "VehicleID" });
            DropIndex("dbo.Vehicle", new[] { "UserID" });
            DropIndex("dbo.Cost", new[] { "VehicleID" });
            DropTable("dbo.Notification");
            DropTable("dbo.User");
            DropTable("dbo.Fuel");
            DropTable("dbo.Vehicle");
            DropTable("dbo.Cost");
        }
    }
}
