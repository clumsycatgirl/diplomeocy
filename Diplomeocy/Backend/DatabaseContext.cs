using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Backend
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Models.User> Users { get; set; } = default!;
    }
}
