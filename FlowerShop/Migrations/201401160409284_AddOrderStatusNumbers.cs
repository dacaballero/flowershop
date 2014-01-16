namespace FlowerShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderStatusNumbers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhoneNumber = c.String(),
                        CarNumber = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Invoice = c.Int(nullable: false),
                        IsDelivery = c.Boolean(nullable: false),
                        DeliveryName = c.String(),
                        DeliveryAddress = c.String(),
                        DeliveryPhone = c.String(),
                        ContactDelivery = c.Boolean(),
                        DeliveryDate = c.DateTime(),
                        DeliveryHour = c.DateTime(nullable: false),
                        OrderStatusId = c.Int(nullable: false),
                        DriverId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.OrderStatus", t => t.OrderStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Drivers", t => t.DriverId)
                .Index(t => t.CustomerId)
                .Index(t => t.OrderStatusId)
                .Index(t => t.DriverId);
            
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StatusNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderStatusChanges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateChanged = c.DateTime(nullable: false),
                        OrderId = c.Int(nullable: false),
                        OrderStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .ForeignKey("dbo.OrderStatus", t => t.OrderStatusId)
                .Index(t => t.OrderId)
                .Index(t => t.OrderStatusId);
           
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            DropIndex("dbo.OrderStatusChanges", new[] { "OrderStatusId" });
            DropIndex("dbo.OrderStatusChanges", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "DriverId" });
            DropIndex("dbo.Orders", new[] { "OrderStatusId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropForeignKey("dbo.OrderStatusChanges", "OrderStatusId", "dbo.OrderStatus");
            DropForeignKey("dbo.OrderStatusChanges", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Orders", "OrderStatusId", "dbo.OrderStatus");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropTable("dbo.OrderStatusChanges");
            DropTable("dbo.OrderStatus");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.Drivers");
        }
    }
}
