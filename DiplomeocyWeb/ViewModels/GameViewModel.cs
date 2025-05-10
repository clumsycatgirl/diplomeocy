using Diplomeocy.Database;
using Diplomeocy.Database.Models;
using Diplomeocy.Database.Services;

namespace Diplomeocy.Web.ViewModels;

public class GameViewModel {
	public required TablesService TablesService { get; init; }
	public required IEnumerable<Player> Players { get; init; }
	public required DatabaseContext Context { get; init; }
}
