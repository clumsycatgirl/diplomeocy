using Diplomeocy.Database.Models;
using Diplomeocy.Extensions;
using Diplomeocy.Web.Exceptions;

namespace Diplomeocy.Database.Services;

public class TablesService {
	private readonly DatabaseContext context;
	private readonly UserService userService;
	private IHttpContextAccessor httpContextAccessor;

	public TablesService(DatabaseContext context, UserService userService, IHttpContextAccessor httpContextAccessor) {
		this.context = context;
		this.userService = userService;
		this.httpContextAccessor = httpContextAccessor;
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

	public IEnumerable<Table> Tables => userService.CurrentUser is not null ? context.Tables.Where(t =>
		t.Host == userService.CurrentUser!.Id
		|| context.Players.Any(player => player.IdTable == t.Id && player.IdUser == userService.CurrentUser!.Id)).ToList() : [];

	public void RequirePlayerOfTable(int tableId) {
		userService.RequireAuthentication();
		Table? table = Tables.FirstOrDefault(t => t.Id == tableId);
		if (table is null) {
			throw new RedirectException("/Tables");
		}
	}

	public Table? CurrentTable {
		get => httpContextAccessor.HttpContext?.Session?.Get<Table>("CurrentTable");
		set {
			ISession? session = httpContextAccessor.HttpContext?.Session;
			if (session is null) {
				return;
			}

			if (value is not null) {
				session.Set("CurrentTable", value);
			} else {
				session.Remove("CurrentTable");
			}
		}
	}
}
