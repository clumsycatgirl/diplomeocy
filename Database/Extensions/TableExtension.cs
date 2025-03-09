using Diplomeocy.Database.Models;

namespace Diplomeocy.Database.Extensions;

public static class TableExtension {
	public static IEnumerable<Player> Players(this Table table, DatabaseContext databaseContext) {
		return databaseContext.Players.Where(player => player.IdTable == table.Id);
	}
}
