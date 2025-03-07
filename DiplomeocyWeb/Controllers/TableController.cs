using Diplomeocy.Database;
using Diplomeocy.Database.Services;
using Diplomeocy.Web.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace Diplomeocy.Web.Controllers;

public class TableController : Controller {
	private readonly ILogger<TableController> logger;
	private readonly DatabaseContext context;
	private readonly TablesService tableService;
	private readonly UserService userService;
	public TableController(DatabaseContext context, UserService userService, TablesService tablesService, ILogger<TableController> logger) {
		this.context = context;
		this.userService = userService;
		this.tableService = tablesService;
		this.logger = logger;
	}

	[HttpGet]
	[Route("Tables")]
	public IActionResult Index() {
		userService.RequireAuthentication();
		return View(new TablesViewModel {
			TablesService = tableService
		});
	}
}
