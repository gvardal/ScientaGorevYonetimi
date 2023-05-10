using Microsoft.EntityFrameworkCore;
using ScientaScheduler.MVC.Models.Domain;

namespace ScientaScheduler.MVC.Data
{
    public class ScientaDbContext : DbContext
    {
        public ScientaDbContext(DbContextOptions<ScientaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UYIsEmri>(mb =>
            {
                mb.HasKey(e => e.IsEmriId);
                mb.Property(e => e.IsEmriKodu)
                .HasMaxLength(10)
                .HasComputedColumnSql("(right('0000000000'+CONVERT([nvarchar],[IsEmriID],(0)),(10)))", false);
            })
                .HasDefaultSchema("UretimYonetimi");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UYIsEmri> UYIsEmri { get; set; }

    }
}
