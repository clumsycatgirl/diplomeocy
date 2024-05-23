using Diplomacy;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using Web.Models;

using MGame = Web.Models.Game;

namespace Web.Controllers {
	[Route("[controller]")]
	public class GameController : Controller {
		private readonly DatabaseContext context;
		private readonly ILogger<GameController> logger;
		private readonly Dictionary<string, GameHandler> gameHandler;

		public GameController(DatabaseContext context, ILogger<GameController> logger, Dictionary<string, GameHandler> gameHandeler) {
			this.context = context;
			this.logger = logger;
			this.gameHandler = gameHandeler;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Index(int id) {
			MGame? game = await context.Games.FirstOrDefaultAsync(g => g.Id == id);
			if (game is null) return NotFound("gaem not found");

			if (!gameHandler.TryGetValue(id.ToString(), out GameHandler? handler)) {
				handler = new GameHandler {
					Players = JsonConvert.DeserializeObject<List<Diplomacy.Player>>(game.PlayerCountries)!,
				};
				gameHandler.Add(id.ToString(), handler);
			}

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
