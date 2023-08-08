using BackendWorks.NonTable;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace BackendWorks.Models
{
    public class TrafficContext:DbContext
    {
        public TrafficContext(DbContextOptions<TrafficContext> options) : base(options) { }

        public DbSet<Traffic> TrafficPolicy { get; set; } = null!;
        public DbSet<Policy> Policy { get; set; } = null!;
        public DbSet<Traffic> Traffic { get; set; } = null!;

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Policy>()
                .HasDiscriminator<string>("ProductType")
                .HasValue<Traffic>("Traffic");
        }*/
    }
}
