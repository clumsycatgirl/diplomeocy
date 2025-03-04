using Diplomeocy.Database.Models;

namespace Diplomeocy.Database.Services;

public class TablesService {
	private readonly DatabaseContext context;
	private readonly UserService userService;

	public TablesService(DatabaseContext context, UserService userService) {
		this.context = context;
		this.userService = userService;
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

		return table;
	}

	public IEnumerable<Table> Tables => context.Tables.Where(t =>
		t.Host == userService.CurrentUser!.Id
		|| context.Players.Any(player => player.IdTable == t.Id && player.IdUser == userService.CurrentUser!.Id)).ToList();
}
