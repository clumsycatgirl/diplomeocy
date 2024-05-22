using Microsoft.EntityFrameworkCore;

namespace Web;

public class DatabaseContext : DbContext {
	public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

	public DbSet<Models.User> Users { get; set; } = default!;
	public DbSet<Models.Player> Players { get; set; } = default!;
	public DbSet<Models.Table> Tables { get; set; } = default!;
	public DbSet<Models.Game> Games { get; set; } = default!;

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<Models.Table>()
			.Property(table => table.Id)
			.ValueGeneratedNever();
	}

}
