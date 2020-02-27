namespace ExpressoAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        MenuId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.MenuId);
            
            CreateTable(
                "dbo.SubMenus",
                c => new
                    {
                        SubMenuId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(),
                        Menu_MenuId = c.Int(),
                    })
                .PrimaryKey(t => t.SubMenuId)
                .ForeignKey("dbo.Menus", t => t.Menu_MenuId)
                .Index(t => t.Menu_MenuId);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.Int(nullable: false),
                        TotalPeople = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Time = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubMenus", "Menu_MenuId", "dbo.Menus");
            DropIndex("dbo.SubMenus", new[] { "Menu_MenuId" });
            DropTable("dbo.Reservations");
            DropTable("dbo.SubMenus");
            DropTable("dbo.Menus");
        }
    }
}
