namespace VehicleWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRunningCost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cost", "CostRunningCost", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cost", "CostRunningCost");
        }
    }
}
