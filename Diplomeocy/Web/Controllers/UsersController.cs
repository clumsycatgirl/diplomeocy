using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Web.Models;
using Web.Utils;

namespace Web.Controllers {
	public class UsersController : Controller {
		private readonly DatabaseContext context;

		public UsersController(DatabaseContext context) {
			this.context = context;
		}

		// GET: Users
		public async Task<IActionResult> Index() {
			return context.Users is not null ?
						View(await context.Users.ToListAsync()) :
						Problem("Entity set 'DatabaseContext.Users'  is null.");
		}

		public IActionResult Me() {
			User? user = HttpContext.Session.Get<User>("User");
			return user is not null ? View(user) : Problem("login first");
		}

		// GET: Users/Details/5
		public async Task<IActionResult> Details(int? id) {
			if (id == null || context.Users == null) {
				return NotFound();
			}

			var user = await context.Users
				.FirstOrDefaultAsync(m => m.Id == id);
			if (user is null) {
				return NotFound();
			}

			return View(user);
		}
		// GET: Users/LogIn
		public IActionResult LogIn() {

			return View();
		}
		// POST: Users/LogIn
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> LogIn(String? username, String? password) {
			List<(string Field, string ErrorMessage)> errors = new();

			if (username is null) {
				errors.Add(("username", "Username is required"));
			}

			if (password is null) {
				errors.Add(("password", "Password is required"));
			}

			if (context.Users is null) {
				// return NotFound();
				errors.Add(("context", "Missing context"));
			}

			if (errors.Any()) {
				return this.JsonError(errors.ToArray());
			}

			User? user = await context.Users!
			   .FirstOrDefaultAsync(m => m.Username == username && m.Password == password);

			if (user is not null) {
				// HttpContext.Session.SetString("UserId", user.Id.ToString());
				HttpContext.Session.Set("User", user);
			}

			return user is null ? this.JsonNotFound("user") : this.JsonRedirect(Url.Action("Details", new { user.Id })!);
		}
		// GET: Users/Create
		public IActionResult Create() {
			return View();
		}

		// POST: Users/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Name,Surname,Username,Password,PathImage")] User user) {

			if (ModelState.IsValid) {
				context.Add(user);
				await context.SaveChangesAsync();
				// return RedirectToAction(nameof(Index)); // automatic redirect 
				// we can't use this with async requests as it'd give us the html as response and then we'd have to do bad stuff

				// set the user in the session
				HttpContext.Session.Set<User>("User", user);

				// we just return *where* to go
				return Json(new { success = true, destination = Url.Action("Details", new { user.Id }) });
			}

			// this refreshes the page
			// return View(user);

			// get all errors and maps them to objects with { Field = state.Key, Errors = [ ...error.ErrorMessage ] }
			List<object> errorList = ModelState
				.Where(state => state.Value is not null && state.Value.Errors.Any())
				.Select(state => new {
					Field = state.Key,
					Errors = state.Value!.Errors.Select(error => error.ErrorMessage).ToList()
				})
				.Cast<object>()
				.ToList();

			// Json is like View inherited from base class
			// automatically parses to json
			// that's an anonymous type cause I was too lazy to make a record for this
			return Json(new { success = false, errors = errorList });
		}

		// GET: Users/Edit/5
		public async Task<IActionResult> Edit(int? id) {
			if (id is null || context.Users is null) {
				return NotFound();
			}

			User? user = await context.Users.FindAsync(id);
			if (user is null) {
				return NotFound();
			}
			return View(user);
		}

		// POST: Users/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Username,Password,PathImage")] User user) {
			if (id != user.Id) {
				return NotFound();
			}

			if (ModelState.IsValid) {
				try {
					context.Update(user);
					await context.SaveChangesAsync();
				} catch (DbUpdateConcurrencyException) {
					if (!UserExists(user.Id)) {
						return NotFound();
					} else {
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(user);
		}

		// GET: Users/Delete/5
		public async Task<IActionResult> Delete(int? id) {
			if (id == null || context.Users == null) {
				return NotFound();
			}

			var user = await context.Users
				.FirstOrDefaultAsync(m => m.Id == id);
			if (user == null) {
				return NotFound();
			}

			return View(user);
		}

		// POST: Users/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id) {
			if (context.Users == null) {
				return Problem("Entity set 'DatabaseContext.Users'  is null.");
			}
			var user = await context.Users.FindAsync(id);
			if (user != null) {
				context.Users.Remove(user);
			}

			await context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool UserExists(int id) {
			return (context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
