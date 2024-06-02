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
			return context.Tables is not null ?
						View(await context.Tables.ToListAsync()) :
						Problem("Entity set 'DatabaseContext.Table'  is null.");
		}

		// GET: Table/Details/5
		public async Task<IActionResult> Details(int? id) {
			if (id is null || context.Tables is null) {
				return NotFound();
			}

			var tables = await context.Tables
				.FirstOrDefaultAsync(m => m.Id == id);
			if (tables is null) {
				return NotFound();
			}

			return View(tables);
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

			context.Tables.Add(new Table {
				Id = tableId,
				Host = user.Id,
				Date = DateOnly.FromDateTime(DateTime.Now),
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

		// GET: Table/Edit/5
		public async Task<IActionResult> Edit(int? id) {
			if (id is null || context.Tables is null) {
				return NotFound();
			}

			var tables = await context.Tables.FindAsync(id);
			if (tables is null) {
				return NotFound();
			}
			return View(tables);
		}

		// POST: Table/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Host")] Table tables) {
			if (id != tables.Id) {
				return NotFound();
			}

			if (ModelState.IsValid) {
				try {
					context.Update(tables);
					await context.SaveChangesAsync();
				} catch (DbUpdateConcurrencyException) {
					if (!TablesExists(tables.Id)) {
						return NotFound();
					} else {
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(tables);
		}

		// GET: Table/Delete/5
		public async Task<IActionResult> Delete(int? id) {
			if (id is null || context.Tables is null) {
				return NotFound();
			}

			var tables = await context.Tables
				.FirstOrDefaultAsync(m => m.Id == id);
			if (tables is null) {
				return NotFound();
			}

			return View(tables);
		}

		// POST: Table/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id) {
			if (context.Tables is null) {
				return Problem("Entity set 'DatabaseContext.Table'  is null.");
			}
			var tables = await context.Tables.FindAsync(id);
			if (tables is not null) {
				context.Tables.Remove(tables);
			}

			await context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool TablesExists(int id) {
			return (context.Tables?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
