namespace FoodOrderMgmtApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foodorder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.foods",
                c => new
                    {
                        FoodId = c.Int(nullable: false, identity: true),
                        FoodCategory = c.Int(nullable: false),
                        FoodName = c.String(),
                        FoodPrice = c.Double(nullable: false),
                        FoodQty = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FoodId)
                .ForeignKey("dbo.foods", t => t.OrderId)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.foods", "OrderId", "dbo.foods");
            DropIndex("dbo.foods", new[] { "OrderId" });
            DropTable("dbo.foods");
        }
    }
}
