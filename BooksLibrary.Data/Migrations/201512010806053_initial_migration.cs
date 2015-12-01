namespace BooksLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        author_id = c.Int(nullable: false, identity: true),
                        full_name = c.String(maxLength: 300),
                        Details = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.author_id);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        book_id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        title_eng = c.String(),
                        Likes = c.Int(nullable: false),
                        Dislikes = c.Int(nullable: false),
                        Pages = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        Edition = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.book_id);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        genre_id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        parent_genre_id = c.Int(),
                    })
                .PrimaryKey(t => t.genre_id);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        tag_id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.tag_id);
            
            CreateTable(
                "dbo.BookAuthor",
                c => new
                    {
                        book_author_id = c.Int(nullable: false, identity: true),
                        book_id = c.Int(nullable: false),
                        author_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.book_author_id);
            
            CreateTable(
                "dbo.BookGenre",
                c => new
                    {
                        book_genre_id = c.Int(nullable: false, identity: true),
                        book_id = c.Int(nullable: false),
                        genre_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.book_genre_id);
            
            CreateTable(
                "dbo.BookTag",
                c => new
                    {
                        book_tag_id = c.Int(nullable: false, identity: true),
                        book_id = c.Int(nullable: false),
                        tag_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.book_tag_id);
            
            CreateTable(
                "dbo.Error",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        user_role_id = c.Int(nullable: false, identity: true),
                        user_id = c.Int(nullable: false),
                        role_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.user_role_id)
                .ForeignKey("dbo.Role", t => t.role_id, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id)
                .Index(t => t.role_id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        user_id = c.Int(nullable: false, identity: true),
                        user_name = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 200),
                        hashed_password = c.String(nullable: false, maxLength: 200),
                        Salt = c.String(nullable: false, maxLength: 200),
                        is_locked = c.Boolean(nullable: false),
                        date_created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.user_id);
            
            CreateTable(
                "dbo.BOOK_GENRE",
                c => new
                    {
                        genre_id = c.Int(nullable: false),
                        book_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.genre_id, t.book_id })
                .ForeignKey("dbo.Book", t => t.genre_id, cascadeDelete: true)
                .ForeignKey("dbo.Genre", t => t.book_id, cascadeDelete: true)
                .Index(t => t.genre_id)
                .Index(t => t.book_id);
            
            CreateTable(
                "dbo.BOOK_TAG",
                c => new
                    {
                        book_id = c.Int(nullable: false),
                        tag_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.book_id, t.tag_id })
                .ForeignKey("dbo.Book", t => t.book_id, cascadeDelete: true)
                .ForeignKey("dbo.Tag", t => t.tag_id, cascadeDelete: true)
                .Index(t => t.book_id)
                .Index(t => t.tag_id);
            
            CreateTable(
                "dbo.BOOK_AUTHOR",
                c => new
                    {
                        author_id = c.Int(nullable: false),
                        book_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.author_id, t.book_id })
                .ForeignKey("dbo.Author", t => t.author_id, cascadeDelete: true)
                .ForeignKey("dbo.Book", t => t.book_id, cascadeDelete: true)
                .Index(t => t.author_id)
                .Index(t => t.book_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "user_id", "dbo.User");
            DropForeignKey("dbo.UserRole", "role_id", "dbo.Role");
            DropForeignKey("dbo.BOOK_AUTHOR", "book_id", "dbo.Book");
            DropForeignKey("dbo.BOOK_AUTHOR", "author_id", "dbo.Author");
            DropForeignKey("dbo.BOOK_TAG", "tag_id", "dbo.Tag");
            DropForeignKey("dbo.BOOK_TAG", "book_id", "dbo.Book");
            DropForeignKey("dbo.BOOK_GENRE", "book_id", "dbo.Genre");
            DropForeignKey("dbo.BOOK_GENRE", "genre_id", "dbo.Book");
            DropIndex("dbo.BOOK_AUTHOR", new[] { "book_id" });
            DropIndex("dbo.BOOK_AUTHOR", new[] { "author_id" });
            DropIndex("dbo.BOOK_TAG", new[] { "tag_id" });
            DropIndex("dbo.BOOK_TAG", new[] { "book_id" });
            DropIndex("dbo.BOOK_GENRE", new[] { "book_id" });
            DropIndex("dbo.BOOK_GENRE", new[] { "genre_id" });
            DropIndex("dbo.UserRole", new[] { "role_id" });
            DropIndex("dbo.UserRole", new[] { "user_id" });
            DropTable("dbo.BOOK_AUTHOR");
            DropTable("dbo.BOOK_TAG");
            DropTable("dbo.BOOK_GENRE");
            DropTable("dbo.User");
            DropTable("dbo.UserRole");
            DropTable("dbo.Role");
            DropTable("dbo.Error");
            DropTable("dbo.BookTag");
            DropTable("dbo.BookGenre");
            DropTable("dbo.BookAuthor");
            DropTable("dbo.Tag");
            DropTable("dbo.Genre");
            DropTable("dbo.Book");
            DropTable("dbo.Author");
        }
    }
}
