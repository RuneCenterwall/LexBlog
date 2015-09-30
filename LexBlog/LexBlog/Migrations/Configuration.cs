namespace LexBlog.Migrations
{
    using LexBlog.Models;
    using LexBlog.Models.BlogDBModels;
    using LexBlog.Models.IdentityModels;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
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
                UserName = "BjornB",
                Email = "bjorn.bjornsson@bmail.com",
                FirstName = "Björn",
                LastName = "Björnsson",
                PhoneNumber = "+462123456",
            };

            ApplicationUser user3 = new ApplicationUser
            {
                UserName = "CarlC",
                Email = "carl.carlsson@cmail.com",
                FirstName = "Carl",
                LastName = "Carlsson",
                PhoneNumber = "+463123456",
            };

            //if (manager.FindByEmail("anders.andersson@amail.com") == null) {
            //    manager.Create(user1, "Aaa-123");
            //}
            //user1 = manager.FindByEmail("anders.andersson@amail.com");
            
            //if (manager.FindByEmail("bjorn.bjornsson@bmail.com") == null) {
            //    manager.Create(user2, "Bbb-123");
            //}
            //user1 = manager.FindByEmail("bjorn.bjornsson@bmail.com");
            
            //if (manager.FindByEmail("carl.carlsson@cmail.com") == null) {
            //    manager.Create(user3, "Ccc-123");
            //}
            //user1 = manager.FindByEmail("carl.carlsson@cmail.com");


            if (manager.FindByName("andersa") == null)
            {
                manager.Create(user1, "Aaa-123");
            }
            user1 = manager.FindByName("andersa");

            if (manager.FindByName("bjornb") == null)
            {
                manager.Create(user2, "Bbb-123");
            }
            user2 = manager.FindByName("bjornb");

            if (manager.FindByName("carlc") == null)
            {
                manager.Create(user3, "Ccc-123");
            }
            user3 = manager.FindByName("carlc");


            //RC: Rest not finished ...
            context.Blogs.AddOrUpdate
                (
                    b => b.Title, // identifier - if this value already exists, update instead of add
                    new Blog()
                    {
                        Title = "TestBlog01",
                        Description = "TestDescr01",
                        Created = DateTime.Now,
                        Edited = DateTime.Now,
                        Views = 10,
                        Owner = user1
                    }
                );

            context.Blogs.AddOrUpdate
                (
                    b => b.Title, // identifier - if this value already exists, update instead of add
                    new Blog()
                    {
                        Title = "TestBlog02",
                        Description = "TestDescr02",
                        Created = DateTime.Now,
                        Edited = DateTime.Now,
                        Views = 20,
                        Owner = user2
                    }
                );

            context.Blogs.AddOrUpdate
                (
                    b => b.Title, // identifier - if this value already exists, update instead of add
                    new Blog()
                    {
                        Title = "TestBlog03",
                        Description = "TestDescr03",
                        Created = DateTime.Now,
                        Edited = DateTime.Now,
                        Views = 30,
                        Owner = user3
                    }
                );

        }
    }
}
