using Diplomacy;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using Web.Utils;

using Web.Hubs;
using Web.Models;
using Web.Serializers.Game;

using MGame = Web.Models.Game;
using Web.Utils;

namespace Web.Controllers {
	[Route("[controller]")]
	public class GameController : Controller {
		private readonly DatabaseContext context;
		private readonly IHubContext<GameHub> hubContext;
		private readonly ILogger<GameController> logger;
		private readonly Dictionary<string, GameHandler> gameHandler;

		public GameController(DatabaseContext context, IHubContext<GameHub> hubContext, ILogger<GameController> logger, Dictionary<string, GameHandler> gameHandeler) {
			this.context = context;
			this.logger = logger;
			this.gameHandler = gameHandeler;
			this.hubContext = hubContext;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Index(int id) {
			MGame? game = await context.Games.FirstOrDefaultAsync(g => g.Id == id);
			if (game is null) return NotFound("gaem not found");

			if (!gameHandler.TryGetValue(id.ToString(), out GameHandler? handler)) {
				handler = new GameHandler {
					Players = JsonConvert.DeserializeObject<List<Diplomacy.Player>>(game.PlayerCountries, new JsonSerializerSettings {
						Converters = { new PlayerConverter() }
					})!,
				};
				handler.Players.ForEach(
					player => player.Countries.ForEach(
						country =>
							country.TerritoriesSerializationNames.ForEach(
								territoryName =>
									country.Territories.Add(handler.Board.Territory(territoryName)))));
				handler.Players.ForEach(
					player => player.UnitsSerializationData.ForEach(
						data =>
							player.Units.Add(new Unit {
								Country = Enum.Parse<Countries>(player.Countries[0].Name),
								Type = (UnitType)int.Parse(data.type),
								Location = handler.Board.Territory(Enum.Parse<Territories>(data.location))
							})));
				handler.Players.ForEach(player => {
					if (!handler.IsPlayerReady.ContainsKey(player)) handler.IsPlayerReady.Add(player, false);
					else handler.IsPlayerReady[player] = false;
				});
				gameHandler.Add(id.ToString(), handler);
			}

			string svgFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", "images", "map.svg");
			string svgContent = System.IO.File.ReadAllText(svgFilePath);
			ViewBag.SvgContent = svgContent;

			var playerList = await context.Players.Where(m => m.IdTable == game.IdTable).ToListAsync();

			List<PlayerModel> userList = new List<PlayerModel>();
			List<PlayerModel> meowList = new List<PlayerModel>();

			meowList.Add(new PlayerModel {
				Id = 0,
				IdTable = 0,
				IdGame = game.Id,
				Username = "meow",
				PathImage = "meow"
			});

			foreach (var p in playerList) {
				var user = await context.Users.FirstOrDefaultAsync(u => u.Id == p.IdUser);
				if (user != null) {
					userList.Add(new PlayerModel {
						Id = user.Id,
						IdTable = game.IdTable,
						IdGame = game.Id,
						Username = user.Username,
						PathImage = user.PathImage
					});
				}
			}

			return View(new GameViewModel {
				Game = game,
				User = HttpContext.Session.Get<User>("User"),
				OwnCountry = HttpContext.Session.Get<string>($"{game.Id}-country") ?? throw new Exception("no country in session"),
				Players = userList.Any() ? userList : meowList,
				Table = context.Tables.FirstOrDefault(table => table.Id == game.IdTable)
					?? throw new Exception("This is impossible"),
			});
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error() {
			return View("Error!");
		}
	}
}
