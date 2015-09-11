namespace LexBlog.Migrations
{
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
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //if (!context.Blogs.Any(b => b.Title == null))
            //{
            //    var Blog = new LexBlog.Models.Blog();
            //    context.Blogs.AddOrUpdate
            //}
            context.Blogs.AddOrUpdate(
                    b => b.Title, // identifier - if this value already exists, update instead of add
                    new LexBlog.Models.Blog()
                    {
                        Title = "TestBlog01",
                        Body = "TestBody01",
                        Created = DateTime.Now,
                        Edited = DateTime.Now,
                        Views = 200
                    }
                );
        }
    }
}
