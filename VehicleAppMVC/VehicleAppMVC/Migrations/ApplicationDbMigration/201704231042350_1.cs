namespace VehicleAppMVC.Migrations.ApplicationDbMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Costs", "CostTotalRunningCost", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Costs", "CostTotalRunningCost");
        }
    }
}
