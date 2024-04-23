using Microsoft.EntityFrameworkCore;

namespace Backend;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options) {

	public DbSet<Models.User> Users { get; set; } = default!;
}

