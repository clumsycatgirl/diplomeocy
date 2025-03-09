using Diplomeocy.Database;
using Diplomeocy.Database.Extensions;
using Diplomeocy.Database.Models;
using Diplomeocy.Database.Services;
using Diplomeocy.Web.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace Diplomeocy.Web.Controllers;

public class GameController : Controller {
	private readonly ILogger<GameController> logger;
	private readonly DatabaseContext context;
	private readonly TablesService tablesService;
	private readonly UserService userService;

	public GameController(ILogger<GameController> logger, DatabaseContext context, TablesService tablesService, UserService userService) {
		this.logger = logger;
		this.context = context;
		this.tablesService = tablesService;
		this.userService = userService;
	}

	[HttpGet]
	[Route("/Game")]
	public IActionResult Index(int table) {
		userService.RequireAuthentication();
		tablesService.RequirePlayerOfTable(table);

		tablesService.CurrentTable = tablesService.Tables.First(t => t.Id == table);

		IEnumerable<Player> players = tablesService.CurrentTable.Players(context);

		return View(new GameViewModel {
			TablesService = tablesService,
			Players = players,
			Context = context,
		});
	}
}
