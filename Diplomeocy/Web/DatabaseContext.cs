using Microsoft.EntityFrameworkCore;

using Web.Models;

namespace Web;

public class DatabaseContext : DbContext {
	public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
	public DbSet<User> Users { get; set; } = default!;
}


