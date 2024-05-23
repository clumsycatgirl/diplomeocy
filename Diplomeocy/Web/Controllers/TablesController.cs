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
		public async Task<IActionResult> Index() {
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
			return View(new UsersPlay {
				Id = 0,
				Date = DateOnly.FromDateTime(DateTime.Now),
				Host = HttpContext.Session.Get<User>("User")?.Id // Get<User> returns User? so it could be null (if there's no "User" key stored it returns null)
					?? throw new Exception("you can only create a table when logged so go log in you dumbass")
			});
		}

		// POST: Table/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Date,Host")] Table table) {
			if (ModelState.IsValid) {
				System.Diagnostics.Debug.WriteLine($"table.Id={table.Id}");

				context.Add(table);
				await context.SaveChangesAsync();

				int? userId = HttpContext.Session.Get<User>("User")?.Id;
				if (userId is null) return NotFound();
				context.Add(new Models.Player {
					IdTable = table.Id,
					IdUser = (int)userId,
				});

				Random random = new Random(Guid.NewGuid().GetHashCode());
				int gameId = random.Next(100000, 1000000);
				while (context.Games.Any(game => game.Id == gameId)) {
					gameId = random.Next(100000, 1000000);
				}

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

				// return RedirectToAction(nameof(Index));
				return this.JsonRedirect(Url.Action("Index", "Game", new { game.Entity.Id })!);
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
