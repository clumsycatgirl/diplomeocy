
using Diplomeocy.Extensions;

using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Diplomeocy.Database;

public class DatabaseContext : DbContext, IDataProtectionKeyContext {
	private readonly IHttpContextAccessor httpContextAccessor;

	public DatabaseContext(DbContextOptions<DatabaseContext> options, IHttpContextAccessor httpContextAccessor) : base(options) {
		this.httpContextAccessor = httpContextAccessor;
	}

	public DbSet<DataProtectionKey> DataProtectionKeys { get; set; } = default!;

	public DbSet<Models.User> Users { get; set; } = default!;
	public DbSet<Models.Table> Tables { get; set; } = default!;
	public DbSet<Models.Player> Players { get; set; } = default!;
	public DbSet<Models.Message> Messages { get; set; } = default!;

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		base.OnModelCreating(modelBuilder);

		// modelBuilder.Model.GetEntityTypes()
		// 	.ToList().ForEach(entityType =>
		// 		modelBuilder.Entity(entityType.ClrType).Property("Id").ValueGeneratedOnAdd());

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

		modelBuilder.Entity<Models.Message>()
			.Property(m => m.Type)
			.HasConversion(
				type => type.ToString(),
				type => Enum.Parse<Models.Types.MessageType>(type, true)
			);

		// IEnumerable<IMutableEntityType> trackableEntityTypes = modelBuilder.Model.GetEntityTypes()
		// 	.Where(type => typeof(Models.ITrackable).IsAssignableFrom(type.ClrType));
		// foreach (IMutableEntityType entityType in trackableEntityTypes) {
		// }
	}

	public override int SaveChanges() {
		OnBeforeSave();
		return base.SaveChanges();
	}

	public override int SaveChanges(bool acceptAllChangesOnSuccess) {
		OnBeforeSave();
		return base.SaveChanges(acceptAllChangesOnSuccess);
	}

	public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) {
		OnBeforeSave();
		return base.SaveChangesAsync(cancellationToken);
	}

	public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default) {
		OnBeforeSave();
		return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
	}

	public void OnBeforeSave() {
		IEnumerable<EntityEntry>? entities = ChangeTracker.Entries()
			.Where(e => e.Entity is Models.ITrackable);

		int? userId = httpContextAccessor.HttpContext?.Session.Get<Models.User?>("CurrentUser")?.Id;

		foreach (EntityEntry entity in entities) {
			if (userId is null) {
				break;
			}

			DateTime now = DateTime.UtcNow;
			switch (entity.State) {
				case EntityState.Added:
					((Models.ITrackable)entity.Entity).CreatedAt = now;
					((Models.ITrackable)entity.Entity).CreatedBy = (int)userId;
					((Models.ITrackable)entity.Entity).UpdatedAt = now;
					((Models.ITrackable)entity.Entity).UpdatedBy = (int)userId;
					break;

				case EntityState.Modified:
					((Models.ITrackable)entity.Entity).UpdatedAt = now;
					((Models.ITrackable)entity.Entity).UpdatedBy = (int)userId;
					break;
			}
		}
	}
}
