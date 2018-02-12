namespace LibraryAutomationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Book_Author",
                c => new
                    {
                        Book_Author_Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Book_Author_Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        BookName = c.String(nullable: false),
                        BookQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);

            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                        TopCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Book_Publisher",
                c => new
                    {
                        Book_Publisher_Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        PublisherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Book_Publisher_Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Publishers", t => t.PublisherId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.PublisherId);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        PublisherId = c.Int(nullable: false, identity: true),
                        PublisherName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PublisherId);
            
            CreateTable(
                "dbo.BookOperations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        UserName = c.String(nullable: false),
                        CategoryName = c.String(nullable: false),
                        BookName = c.String(nullable: false),
                        AuthorName = c.String(nullable: false),
                        PublisherName = c.String(nullable: false),
                        ReceivingDate = c.DateTime(nullable: false),
                        GivingDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Penalties",
                c => new
                    {
                        PenaltyId = c.Int(nullable: false, identity: true),
                        BookOperationId = c.Int(nullable: false),
                        PenaltyQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PenaltyId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Mail = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Book_Publisher", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.Book_Publisher", "BookId", "dbo.Books");
            DropForeignKey("dbo.Book_Author", "BookId", "dbo.Books");
            DropForeignKey("dbo.Books", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Book_Author", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Book_Publisher", new[] { "PublisherId" });
            DropIndex("dbo.Book_Publisher", new[] { "BookId" });
            DropIndex("dbo.Books", new[] { "CategoryId" });
            DropIndex("dbo.Book_Author", new[] { "AuthorId" });
            DropIndex("dbo.Book_Author", new[] { "BookId" });
            DropTable("dbo.Users");
            DropTable("dbo.Penalties");
            DropTable("dbo.BookOperations");
            DropTable("dbo.Publishers");
            DropTable("dbo.Book_Publisher");
            DropTable("dbo.Categories");
            DropTable("dbo.Books");
            DropTable("dbo.Book_Author");
            DropTable("dbo.Authors");
        }
    }
}
