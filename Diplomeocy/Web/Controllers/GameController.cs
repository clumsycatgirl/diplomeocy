using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Web.Models;

using MGame = Web.Models.Game;

namespace Web.Controllers {
	[Route("[controller]")]
	public class GameController : Controller {
		private readonly DatabaseContext context;
		private readonly ILogger<GameController> logger;

		public GameController(DatabaseContext context, ILogger<GameController> logger) {
			this.context = context;
			this.logger = logger;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Index(int id) {
			MGame? game = await context.Games.FirstOrDefaultAsync(g => g.Id == id);
			if (game is null) return NotFound("gaem not found");

			return View(new GameViewModel {
				Game = game,
				Players = context.Players.Where(player => player.IdTable == game.IdTable).ToList(),
				Table = context.Tables.FirstOrDefault(table => table.Id == game.IdTable) ?? throw new Exception("no this is impossible"),
			});
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error() {
			return View("Error!");
		}
	}
}
