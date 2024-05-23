using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using Web;
using Web.Models;

namespace Web.Controllers {
	public class PlayersController : Controller {
		private readonly DatabaseContext context;

		public PlayersController(DatabaseContext context) {
			this.context = context;
		}

		// GET: Players
		public async Task<IActionResult> Index() {
			return context.Players != null ?
						View(await context.Players.ToListAsync()) :
						Problem("Entity set 'DatabaseContext.Players'  is null.");
		}

		// GET: Players/Details/5
		public async Task<IActionResult> Details(int? id) {
			if (id == null || context.Players == null) {
				return NotFound();
			}

			var players = await context.Players
				.FirstOrDefaultAsync(m => m.Id == id);
			if (players == null) {
				return NotFound();
			}

			return View(players);
		}

		// GET: Players/Create
		public IActionResult Create() {
			return View();
		}

		// POST: Players/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,IdTable,IdUser")] Player players) {
			if (ModelState.IsValid) {
				context.Add(players);
				await context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(players);
		}

		// GET: Players/Edit/5
		public async Task<IActionResult> Edit(int? id) {
			if (id == null || context.Players == null) {
				return NotFound();
			}

			var players = await context.Players.FindAsync(id);
			if (players == null) {
				return NotFound();
			}
			return View(players);
		}

		// POST: Players/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,IdTable,IdUser")] Player players) {
			if (id != players.Id) {
				return NotFound();
			}

			if (ModelState.IsValid) {
				try {
					context.Update(players);
					await context.SaveChangesAsync();
				} catch (DbUpdateConcurrencyException) {
					if (!PlayersExists(players.Id)) {
						return NotFound();
					} else {
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(players);
		}

		// GET: Players/Delete/5
		public async Task<IActionResult> Delete(int? id) {
			if (id == null || context.Players == null) {
				return NotFound();
			}

			var players = await context.Players
				.FirstOrDefaultAsync(m => m.Id == id);
			if (players == null) {
				return NotFound();
			}

			return View(players);
		}

		// POST: Players/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id) {
			if (context.Players == null) {
				return Problem("Entity set 'DatabaseContext.Players'  is null.");
			}
			var players = await context.Players.FindAsync(id);
			if (players != null) {
				context.Players.Remove(players);
			}

			await context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool PlayersExists(int id) {
			return (context.Players?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
