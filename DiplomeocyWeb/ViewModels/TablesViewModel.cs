using Diplomeocy.Database;
using Diplomeocy.Database.Models;
using Diplomeocy.Database.Services;

namespace Diplomeocy.Web.ViewModels;

public class TablesViewModel {
	public required TablesService TablesService { get; init; }
	public required DatabaseContext Context { get; init; }
	public Table? SelectedTable { get; init; } = null;
}
