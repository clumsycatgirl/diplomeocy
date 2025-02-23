using Diplomeocy.Database.Models;

namespace Diplomeocy.Database.Services;

public class TablesService {
	public List<Table>? Tables { get; private set; } = null;

	private DatabaseContext context;
	private UserService userService;
	public void TableService(DatabaseContext context, UserService userService) {
		this.context = context;
		this.userService = userService;
	}

	public void SetTables(List<Table>? tables) {
		Tables = tables;
	}

	public Table CreateTable() {
		Random rng = new Random(Guid.NewGuid().GetHashCode());
		int tableId = rng.Next(100000, 999999 + 1);
		while (context.Tables.Any(table => table.Id == tableId)) {
			tableId = rng.Next(100000, 999999 + 1);
		}

		Table table = new Table {
			Id = tableId,
			Host = userService.CurrentUser?.Id ?? -1,
			Date = DateOnly.FromDateTime(DateTime.Now),
		};

		context.Tables.Add(table);
		context.SaveChanges();

		(Tables ??= []).Add(table);

		return table;
	}
}
