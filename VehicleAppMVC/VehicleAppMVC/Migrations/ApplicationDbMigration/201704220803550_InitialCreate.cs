namespace VehicleAppMVC.Migrations.ApplicationDbMigration
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
                        CostTitle = c.Int(nullable: false),
                        CostDate = c.DateTime(nullable: false),
                        CostOdometerMileage = c.Int(nullable: false),
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
                        ApplicationUserId = c.String(maxLength: 128),
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
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationID = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        NotificationDate = c.DateTime(nullable: false),
                        NotificationSendDate = c.DateTime(nullable: false),
                        NotificationType = c.Int(nullable: false),
                        NotificationTitle = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NotificationID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Fuels", "VehicleID", "dbo.Vehicles");
            DropForeignKey("dbo.Costs", "VehicleID", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notifications", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Fuels", new[] { "VehicleID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Notifications", new[] { "ApplicationUserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Vehicles", new[] { "ApplicationUserId" });
            DropIndex("dbo.Costs", new[] { "VehicleID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Fuels");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Notifications");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Costs");
        }
    }
}
