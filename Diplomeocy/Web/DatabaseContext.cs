using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Web;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public DbSet<Models.User> Users { get; set; } = default!;
	public DbSet<Models.Players> Players { get; set; } = default!;
	public DbSet<Models.Tables> Tables { get; set; } = default!;
	public DbSet<Models.Games> Games { get; set; } = default!;
}
