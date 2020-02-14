namespace UD_WebAPI_Course.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuoteCreatedAtAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quotes", "CreatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Quotes", "CreatedAt");
        }
    }
}
