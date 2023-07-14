using Microsoft.EntityFrameworkCore;

namespace BackendWorks.Models
{
    public class FirstContext : DbContext
    {

        public FirstContext(DbContextOptions<FirstContext> options)
            : base(options)
        { 
        }

        DbSet<First> Firsts { get; set; } = null!;
    }
}
