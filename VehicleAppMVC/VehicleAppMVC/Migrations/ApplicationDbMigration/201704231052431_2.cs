namespace VehicleAppMVC.Migrations.ApplicationDbMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Costs", "CostTotalRunningCost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Costs", "CostTotalRunningCost", c => c.Double(nullable: false));
        }
    }
}
