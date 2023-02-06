namespace FoodOrderMgmtApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        CustomerAddress = c.String(),
                        CustomerContactNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.customers");
        }
    }
}
