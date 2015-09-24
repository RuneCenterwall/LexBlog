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

            ApplicationUser user1 = new ApplicationUser
            {
                UserName = "AndersA",
                Email = "anders.andersson@amail.com",
                FirstName = "Anders",
                LastName = "Andersson",
                PhoneNumber = "+461123456",
            };

            ApplicationUser user2 = new ApplicationUser
            {
                UserName = "BjörnB",
                Email = "bjorn.bjornsson@amail.com",
                FirstName = "Björn",
                LastName = "Björnsson",
                PhoneNumber = "+462123456",
            };

            ApplicationUser user3 = new ApplicationUser
            {
                UserName = "CarlC",
                Email = "carl.carlsson@amail.com",
                FirstName = "Carl",
                LastName = "Carlsson",
                PhoneNumber = "+463123456",
            };

            manager.Create(user1, "Aaa-123");
            manager.Create(user2, "Bbb-123");
            manager.Create(user3, "Ccc-123");

            //RC: Rest not finished ...
            context.Blogs.AddOrUpdate(
                    b => b.Title, // identifier - if this value already exists, update instead of add
                    new LexBlog.Models.Blog()
                    {
                        Title = "TestBlog01",
                        Description = "TestDescr01",
                        Created = DateTime.Now,
                        Edited = DateTime.Now,
                        Views = 10
                        Owner = manager.Users.First<context>
                        {

                    }

                    }
                );

        }
    }
}
