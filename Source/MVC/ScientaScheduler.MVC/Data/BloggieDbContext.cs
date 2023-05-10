using Microsoft.EntityFrameworkCore;
using ScientaScheduler.MVC.Models.Domain;

namespace ScientaScheduler.MVC.Data
{
    public class BloggieDbContext : DbContext
    {
        public BloggieDbContext(DbContextOptions<BloggieDbContext> options) : base(options)
        {

        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
