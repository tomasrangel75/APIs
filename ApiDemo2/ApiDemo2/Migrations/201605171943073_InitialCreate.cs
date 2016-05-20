namespace ApiDemo2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        PostDate = c.DateTime(nullable: false),
                        Publisher = c.String(),
                        IdBlog = c.Int(nullable: false),
                        PostBlog_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blogs", t => t.PostBlog_Id)
                .Index(t => t.PostBlog_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "PostBlog_Id", "dbo.Blogs");
            DropIndex("dbo.Posts", new[] { "PostBlog_Id" });
            DropTable("dbo.Posts");
            DropTable("dbo.Blogs");
        }
    }
}
