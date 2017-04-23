namespace VehicleAppMVC.Migrations.ApplicationDbMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Fuels", "FuelConsumption");
            DropColumn("dbo.Fuels", "FuelCost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fuels", "FuelCost", c => c.Double(nullable: false));
            AddColumn("dbo.Fuels", "FuelConsumption", c => c.Double(nullable: false));
        }
    }
}
