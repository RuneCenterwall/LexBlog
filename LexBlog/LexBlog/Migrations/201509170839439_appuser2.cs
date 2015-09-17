namespace LexBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appuser2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blogs", "Owner_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Blogs", new[] { "Owner_Id" });
            AddColumn("dbo.Blogs", "Owner", c => c.Int(nullable: false));
            DropColumn("dbo.Blogs", "Owner_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "Owner_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Blogs", "Owner");
            CreateIndex("dbo.Blogs", "Owner_Id");
            AddForeignKey("dbo.Blogs", "Owner_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
