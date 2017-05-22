namespace VehicleAppMVC.Migrations.ApplicationDbMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fuels", "StripeToken", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fuels", "StripeToken");
        }
    }
}
