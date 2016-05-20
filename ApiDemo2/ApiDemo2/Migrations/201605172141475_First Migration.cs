namespace ApiDemo2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "Publisher", c => c.String(nullable: false));
		    }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Publisher", c => c.String());
            AlterColumn("dbo.Posts", "Title", c => c.String());
            AlterColumn("dbo.Blogs", "Name", c => c.String());
        }
    }
}
