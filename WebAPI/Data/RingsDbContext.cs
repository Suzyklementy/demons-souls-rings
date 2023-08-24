using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using WebAPI.Entities;

namespace WebAPI.Data
{
    public class RingsDbContext : DbContext
    {
        public RingsDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WayToGet>()
                .HasIndex(w => new { w.RingId })
                .IsUnique(false);
        }

        public DbSet<Ring> Rings { get; set; }
        public DbSet<WayToGet> HowToGet { get; set; }
    }
}
