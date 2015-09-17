namespace LexBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "Owner_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Blogs", "Owner_Id");
            AddForeignKey("dbo.Blogs", "Owner_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Blogs", "Owner");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "Owner", c => c.Int(nullable: false));
            DropForeignKey("dbo.Blogs", "Owner_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Blogs", new[] { "Owner_Id" });
            DropColumn("dbo.Blogs", "Owner_Id");
        }
    }
}
