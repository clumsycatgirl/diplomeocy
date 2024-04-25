using Microsoft.EntityFrameworkCore;

using Web.Models;

namespace Web;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options) {
	public DbSet<User> Users { get; set; } = default!;
}


