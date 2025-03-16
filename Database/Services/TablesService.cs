using Diplomeocy.Database.Models;
using Diplomeocy.Web.Exceptions;

namespace Diplomeocy.Database.Services;

public class TablesService : BaseService<Table> {
	private readonly ILogger<TablesService> logger;
	private readonly UserService userService;

	public override required string Key { get; init; } = "CurrentTable";
	public Table? CurrentTable {
		get => Value;
		set => Value = value;
	}

	public TablesService(ILogger<TablesService> logger, DatabaseContext databaseContext, UserService userService, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor, databaseContext) {
		this.logger = logger;
		this.userService = userService;
	}

	public Table CreateTable() {
		Random rng = new Random(Guid.NewGuid().GetHashCode());
		int tableId = rng.Next(100000, 999999 + 1);
		while (databaseContext.Tables.Any(table => table.Id == tableId)) {
			tableId = rng.Next(100000, 999999 + 1);
		}

		Table table = new Table {
			Id = tableId,
			Host = userService.CurrentUser!.Id,
			Date = DateOnly.FromDateTime(DateTime.Now),
		};

		databaseContext.Tables.Add(table);
		databaseContext.SaveChanges();

		logger.LogInformation($"Created table {table.Id} with host player {userService.CurrentUser!.Id}");

		return table;
	}

	public IEnumerable<Table> Tables => userService.CurrentUser is not null ? databaseContext.Tables.Where(t =>
		t.Host == userService.CurrentUser!.Id
		|| databaseContext.Players.Any(player => player.IdTable == t.Id && player.IdUser == userService.CurrentUser!.Id)).ToList() : [];

	public void RequireValidTable(int? id = null) {
		if (id is not null) {
			CurrentTable = databaseContext.Tables.FirstOrDefault(t => t.Id == id);
		}
		if (CurrentTable is null) {
			throw new RedirectException("/Tables");
		}
	}
}
