
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DiplomeocyWeb.Database;

public class DatabaseContext : DbContext, IDataProtectionKeyContext {
	public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

	public DbSet<DataProtectionKey> DataProtectionKeys { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		base.OnModelCreating(modelBuilder);

		//modelBuilder.Entity<Models.Table>()
		//			  .Property(table => table.Id)
		//			  .ValueGeneratedNever();
	}
}
