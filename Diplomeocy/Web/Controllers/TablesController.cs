using System;

using Diplomacy;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using Newtonsoft.Json;

using Web.Models;
using Web.Utils;

namespace Web.Controllers {
	public class TablesController : Controller {
		private readonly DatabaseContext context;
		private readonly ILogger<TablesController> logger;
		private readonly Dictionary<string, GameHandler> gameHandlers;

		public TablesController(DatabaseContext context, ILogger<TablesController> logger, Dictionary<string, GameHandler> gameHandlers) {
			this.context = context;
			this.logger = logger;
			this.gameHandlers = gameHandlers;
		}

		// GET: Table
		[Route("/Table/i/{id}")]
		public async Task<IActionResult> Index(int id) {
			Table? table = await context.Tables.FindAsync(id);
			if (table is null) return Redirect(Url.Action("Index", "Home")!);

			Models.Game game = await context.Games.FirstAsync(game => game.IdTable == table.Id);
			// Models.TableViewModel.PlayerData[] players = await context.Players.Where(player => player.IdTable == table.Id).ToArrayAsync();
			Models.TableViewModel.PlayerData[] playersData = await context.Players.Join(inner: context.Users,
				player => player.IdUser,
				user => user.Id,
				(player, user) => new Models.TableViewModel.PlayerData {
					Player = player,
					User = user,
				}).Where(playerData => playerData.Player.IdTable == table.Id).ToArrayAsync();

			return View(new Models.TableViewModel {
				Table = table,
				Players = playersData,
				Game = game,
			});
		}

		[HttpPost]
		[Route("/Table/Join/{id}")]
		public async Task<IActionResult> Join(int id) {
			if (!TablesExists(id)) return this.JsonNotFound("table");

			bool isPlayerAlreadyInTable = await context.Players.AnyAsync(player => player.IdTable == id && player.IdUser == HttpContext.Session.Get<User>("User")!.Id);
			if (isPlayerAlreadyInTable) return this.JsonRedirect(Url.Action("i", "Table", new { Id = id })!);

			int playersInTable = await context.Players.CountAsync(player => player.IdTable == id);
			if (playersInTable >= 7) return this.JsonError(("table", "is full"));

			User user = HttpContext.Session.Get<User>("User")!;

			await context.Players.AddAsync(new Models.Player {
				IdTable = id,
				IdUser = user.Id,
			});
			await context.SaveChangesAsync();

			return this.JsonRedirect(Url.Action("i", "Table", new { Id = id })!);
		}

		// GET: Table/Create
		public IActionResult Create() {
			User? user = HttpContext.Session.Get<User>("User");
			if (user is null) {
				return Redirect(Url.Action("Index", "Home")!);
			}

			Random rng = new Random(Guid.NewGuid().GetHashCode());
			int tableId = rng.Next(100000, 999999 + 1);
			while (context.Tables.Any(table => table.Id == tableId)) {
				tableId = rng.Next(100000, 999999 + 1);
			}

			context.Tables.Add(new Models.Table {
				Id = tableId,
				Host = user.Id,
				Date = DateOnly.FromDateTime(DateTime.Now),
			});
			context.SaveChanges();
			context.Players.Add(new Models.Player {
				IdTable = tableId,
				IdUser = user.Id,
			});
			context.Games.Add(new Models.Game {
				IdTable = tableId,
			});
			context.SaveChanges();

			return Redirect(Url.Action("i", "Table", new { Id = tableId })!);
		}

		// POST: Table/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Date,Host")] Table table) {
			if (ModelState.IsValid) {
				context.Add(table);
				await context.SaveChangesAsync();

				int? userId = HttpContext.Session.Get<User>("User")?.Id;
				if (userId is null) return NotFound();
				context.Add(new Models.Player {
					IdTable = table.Id,
					IdUser = (int)userId,
				});
				await context.SaveChangesAsync();
				int gameId = table.Id;


				GameHandler handler = new GameHandler();
				handler.StartGame();
				EntityEntry<Models.Game> game = context.Add(new Models.Game {
					Id = gameId,
					IdTable = table.Id,
					PlayerCountries = JsonConvert.SerializeObject(handler!.Players, new JsonSerializerSettings {
						Converters = { new Serializers.Game.PlayerConverter() }
					}),
				});

				await context.SaveChangesAsync();

				gameHandlers.Add(game.Entity.Id.ToString(), handler);

				List<Countries> availableCountries = Enum.GetValues<Countries>()
						.Where(country => !handler.Players.Any(player => player.Countries.Any(c => c.Name == country.ToString())))
						.ToList();

				Countries country = availableCountries[new Random(Guid.NewGuid().GetHashCode()).Next(0, availableCountries.Count)];
				(Country country, List<Unit> units) playerData = handler.CreatePlayerData(country);

				handler!.Players.Add(new Diplomacy.Player {
					Name = context.Users.Find(userId)?.Username ?? "Unknown",
					Countries = new List<Country>() {
							playerData.country,
						},
					Units = playerData.units,
				});
				HttpContext.Session.Set<string>($"{gameId}-country", playerData.country.Name);

				//return RedirectToAction(nameof(Index));
				return table is null ? this.JsonNotFound("tables") : this.JsonRedirect(Url.Action("StartGame", "Players", new { id = table.Id })!);
			}
			// return View(table);
			return this.JsonError(("Sorry", "Something went wrong"));
		}

		private bool TablesExists(int id) {
			return (context.Tables?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
