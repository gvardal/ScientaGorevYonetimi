using Microsoft.EntityFrameworkCore;
using ScientaScheduler.MVC.Library.Models;

namespace ScientaScheduler.MVC.Library
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UYIsEmri>(mb =>
            {
                mb.HasKey(e => e.IsEmriId);
            }).HasDefaultSchema("UretimYonetimi");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UYIsEmri> UYIsEmri { get; set; }
    }
}
