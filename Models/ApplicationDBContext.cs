using Microsoft.EntityFrameworkCore;

namespace EarlyMan.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options) { }

        public DbSet<Print> Prints { get; set; }
        public DbSet<Promotion> Promos { get; set; }
    }
}