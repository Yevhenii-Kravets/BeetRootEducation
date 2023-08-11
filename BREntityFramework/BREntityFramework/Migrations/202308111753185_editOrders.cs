namespace BREntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editOrders : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            RenameColumn(table: "dbo.Orders", name: "Customer_Id", newName: "CustomerId");
            AlterColumn("dbo.Orders", "CustomerId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Orders", "CustomerId");
            AddForeignKey("dbo.Orders", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "UserId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            AlterColumn("dbo.Orders", "CustomerId", c => c.Guid());
            RenameColumn(table: "dbo.Orders", name: "CustomerId", newName: "Customer_Id");
            CreateIndex("dbo.Orders", "Customer_Id");
            AddForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
