namespace LexBlog.Migrations
{
    using LexBlog.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LexBlog.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LexBlog.Models.ApplicationDbContext context)
        {
            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);

            ApplicationUser user1 = new ApplicationUser {
                UserName = "Per",
                Email = "per@per.biz"
            };

            manager.Create(user1, "Pelle");

            context.Blogs.AddOrUpdate(
                    b => b.Title, // identifier - if this value already exists, update instead of add
                    new LexBlog.Models.Blog()
                    {
                        Title = "TestBlog01",
                        Description = "TestBody01",
                        Created = DateTime.Now,
                        Edited = DateTime.Now,
                        Views = 200
                    }
                );
        }
    }
}
