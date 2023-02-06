namespace FoodOrderMgmtApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customer1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.customers", "CustomerFirstName", c => c.String());
            AddColumn("dbo.customers", "CustomerLastName", c => c.String());
            AddColumn("dbo.customers", "CustomerEmailId", c => c.String());
            AddColumn("dbo.customers", "CustomerPhone", c => c.String());
            DropColumn("dbo.customers", "CustomerName");
            DropColumn("dbo.customers", "CustomerContactNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.customers", "CustomerContactNo", c => c.Int(nullable: false));
            AddColumn("dbo.customers", "CustomerName", c => c.String());
            DropColumn("dbo.customers", "CustomerPhone");
            DropColumn("dbo.customers", "CustomerEmailId");
            DropColumn("dbo.customers", "CustomerLastName");
            DropColumn("dbo.customers", "CustomerFirstName");
        }
    }
}
