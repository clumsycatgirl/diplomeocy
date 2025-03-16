using Diplomeocy.Database;
using Diplomeocy.Database.Extensions;
using Diplomeocy.Database.Models;
using Diplomeocy.Database.Services;
using Diplomeocy.Extensions;
using Diplomeocy.Web.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace Diplomeocy.Web.Controllers;

public class TableController : Controller {
	private readonly IHttpContextAccessor httpContextAccessor;
	private readonly ILogger<TableController> logger;
	private readonly DatabaseContext context;
	private readonly TablesService tableService;
	private readonly UserService userService;
	private readonly PlayerService playerService;
	public TableController(IHttpContextAccessor httpContextAccessor, DatabaseContext context, UserService userService, TablesService tablesService, ILogger<TableController> logger, PlayerService playerService) {
		this.httpContextAccessor = httpContextAccessor;
		this.context = context;
		this.userService = userService;
		this.tableService = tablesService;
		this.logger = logger;
		this.playerService = playerService;
	}

	[HttpGet]
	[Route("Tables")]
	public IActionResult Index() {
		userService.RequireAuthentication();

		return View(new TablesViewModel {
			TablesService = tableService,
			Context = context,
			SelectedTable = tableService.CurrentTable,
		});
	}

	[HttpPost]
	[Route("Table/Join/{tableId:int}")]
	public IActionResult Join(int tableId) {
		userService.RequireAuthentication();

		Table? table = context.Tables.FirstOrDefault((t) => t.Id == tableId);
		if (table is null) {
			return this.JsonError(("tableId", "invalid table id"));
		}

		if (table.IsFull(context)) {
			return this.JsonError(("tableId", "table is full"));
		}

		tableService.CurrentTable = table!;
		Player player = playerService.CreatePlayer();
		logger.LogInformation($"user {userService.CurrentUser!.Id} joined table {table!.Id} as player {player.Id}");

		return this.JsonRedirect("/Tables");
	}
}
