namespace FoodOrderMgmtApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerorder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderQty = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.orders", t => t.CustomerId)
                .ForeignKey("dbo.customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.orders", "CustomerId", "dbo.customers");
            DropForeignKey("dbo.orders", "CustomerId", "dbo.orders");
            DropIndex("dbo.orders", new[] { "CustomerId" });
            DropTable("dbo.orders");
        }
    }
}
