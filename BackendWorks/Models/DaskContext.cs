using Microsoft.EntityFrameworkCore;

namespace BackendWorks.Models
{
    public class DaskContext:DbContext
    {
        public DaskContext(DbContextOptions<DaskContext> options) : base(options) { }

        public DbSet<Dask> DaskPolicy { get; set; } = null!;
        public DbSet<Policy> Policy { get; set; } = null!;

        public DbSet<Dask> Dask { get; set; } = null!;

    }
}
