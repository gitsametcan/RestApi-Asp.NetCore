using Microsoft.EntityFrameworkCore;

namespace BackendWorks.Models
{
    public class PolicyContext :DbContext
    {
        public PolicyContext(DbContextOptions<PolicyContext> options) : base(options)
        {

        }

        public DbSet<Policy> Policy { get; set; } = null!;
    }
}
