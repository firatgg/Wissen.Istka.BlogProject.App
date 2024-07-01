using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wissen.Istka.BlogProject.App.Entity.Entities;

namespace Wissen.Istka.BlogProject.App.DataAccess.Contexts
{
    public class BlogDbContext : IdentityDbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Article>().Property("Title").IsRequired().HasMaxLength(200);
            builder.Entity<Article>().Property("Summary").IsRequired().HasMaxLength(500);
            builder.Entity<Category>().Property("Name").IsRequired().HasMaxLength(100);
            builder.Entity<Tag>().Property("Content").IsRequired().HasMaxLength(20);
            builder.Entity<Comment>().Property("Content").IsRequired();
            base.OnModelCreating(builder);
        }
    }
}
