namespace BooksLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "Image", c => c.String());
            AddColumn("dbo.Book", "Rating", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book", "Rating");
            DropColumn("dbo.Book", "Image");
        }
    }
}
