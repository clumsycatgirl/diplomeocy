using Diplomeocy.Database.Models;
using Diplomeocy.Database.Models.Types;

namespace Diplomeocy.Database.Extensions;

public static class TableExtension {
	public static IEnumerable<Player> Players(this Table table, DatabaseContext databaseContext) {
		return databaseContext.Players.Where(player => player.IdTable == table.Id);
	}

	public static Country? GetRandomAvailableCountry(this Table table, DatabaseContext databaseContext) {
		if (table.IsFull(databaseContext)) return null;

		IEnumerable<Player> players = table.Players(databaseContext);
		IEnumerable<Country> usedCountries = players.Select(p => p.Country);
		IEnumerable<Country> countries = Enum.GetValues<Country>();
		IEnumerable<Country> unusedCountries = countries.Where(c => !usedCountries.Contains(c));
		Random random = new Random(Guid.NewGuid().GetHashCode());

		return unusedCountries.ElementAt(random.Next(0, unusedCountries.Count() + 1));
	}

	public static bool IsFull(this Table table, DatabaseContext databaseContext) {
		return table.Players(databaseContext).Count() == Enum.GetValues<Country>().Length;
	}
}
