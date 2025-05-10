
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Diplomeocy.Database;

public class DatabaseContext : DbContext, IDataProtectionKeyContext {
	public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

	public DbSet<DataProtectionKey> DataProtectionKeys { get; set; } = default!;

	public DbSet<Models.User> Users { get; set; } = default!;
	public DbSet<Models.Table> Tables { get; set; } = default!;
	public DbSet<Models.Player> Players { get; set; } = default!;
	public DbSet<Models.Message> Messages { get; set; } = default!;

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<Models.Table>()
		.Property(table => table.Id)
					  .ValueGeneratedNever();

		modelBuilder.Entity<Models.User>()
			.Property(user => user.Theme)
			.HasConversion(
				theme => theme.ToString(),
				theme => Enum.Parse<Models.Types.Theme>(theme, true)
			);

		modelBuilder.Entity<Models.Player>()
			.Property(p => p.Country)
			.HasConversion(
				country => country.ToString(),
				country => Enum.Parse<Models.Types.Country>(country, true)
			);
	}
}
