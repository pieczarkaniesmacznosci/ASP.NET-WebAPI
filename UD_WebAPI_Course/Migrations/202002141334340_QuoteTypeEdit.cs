namespace UD_WebAPI_Course.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuoteTypeEdit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quotes", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Quotes", "Type");
        }
    }
}
