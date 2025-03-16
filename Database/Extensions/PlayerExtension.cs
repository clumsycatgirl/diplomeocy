using Diplomeocy.Database.Models;

namespace Diplomeocy.Database.Extensions;

public static class PlayerExtension {
	public static User User(this Player player, DatabaseContext databaseContext) {
		return databaseContext.Users.First(user => user.Id == player.IdUser);
	}
}
