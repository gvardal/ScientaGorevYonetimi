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
                mb.ToTable("UYIsEmri", "UretimYonetimi");
                mb.HasKey(e => e.IsEmriId);
            });

            modelBuilder.Entity<P_UYIsEmriDurumu>(mb =>
            {
                mb.ToTable("P_UYIsEmriDurumu", "SistemAyarlari");
                mb.HasKey(e => e.IsEmriDurumID);
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UYIsEmri> UYIsEmri { get; set; }
        public DbSet<P_UYIsEmriDurumu> P_UYIsEmriDurumu { get; set; }
    }
}
