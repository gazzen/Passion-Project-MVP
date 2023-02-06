namespace FoodOrderMgmtApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderfood : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.orders", "CustomerId", "dbo.orders");
            DropForeignKey("dbo.foods", "OrderId", "dbo.foods");
            AddForeignKey("dbo.foods", "OrderId", "dbo.orders", "OrderId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.foods", "OrderId", "dbo.orders");
            AddForeignKey("dbo.foods", "OrderId", "dbo.foods", "FoodId");
            AddForeignKey("dbo.orders", "CustomerId", "dbo.orders", "OrderId");
        }
    }
}
