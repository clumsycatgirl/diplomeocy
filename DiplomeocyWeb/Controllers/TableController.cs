using Diplomeocy.Database;
using Diplomeocy.Database.Models;
using Diplomeocy.Extensions;
using Diplomeocy.Web.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace Diplomeocy.Web.Controllers;
public class TableController : Controller {
	private readonly DatabaseContext context;
	public TableController(DatabaseContext context) {
		this.context = context;
	}

	[HttpGet]
	[Route("Tables")]
	public IActionResult Index() {
		User? user = HttpContext.Session.Get<User>("User");
		if (user is null) {
			return RedirectToAction("Index", "Auth");
		}

		IEnumerable<Table> tables = context.Tables
			.Where(table => table.Host == user.Id ||
				context.Players.Any(player => player.IdTable == table.Id && player.IdUser == user.Id));

		foreach (var item in tables) {

		}

		return View(new TablesViewModel() { Tables = tables });
	}
}
