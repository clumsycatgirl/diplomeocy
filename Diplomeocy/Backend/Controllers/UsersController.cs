using Backend.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase {
		private readonly DatabaseContext _context;

		public UsersController(DatabaseContext context) {
			_context = context;
		}

		// GET: api/Users
		[HttpGet]
		public async Task<ActionResult<IEnumerable<User>>> GetUsers() {
			return await _context.Users.ToListAsync();
		}

		// GET: api/Users/5
		[HttpGet("{id}")]
		public async Task<ActionResult<User>> GetUsers(int id) {
			var Users = await _context.Users.FindAsync(id);

			if (Users == null) {
				return NotFound();
			}

			return Users;
		}

		// PUT: api/Users/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutUsers(int id, User Users) {
			if (id != Users.Id) {
				return BadRequest();
			}

			_context.Entry(Users).State = EntityState.Modified;

			try {
				await _context.SaveChangesAsync();
			} catch (DbUpdateConcurrencyException) {
				if (!UsersExists(id)) {
					return NotFound();
				} else {
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Users
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<User>> PostUsers(User Users) {
			_context.Users.Add(Users);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetUsers", new { id = Users.Id }, Users);
		}

		// DELETE: api/Users/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUsers(int id) {
			var Users = await _context.Users.FindAsync(id);
			if (Users == null) {
				return NotFound();
			}

			_context.Users.Remove(Users);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool UsersExists(int id) {
			return _context.Users.Any(e => e.Id == id);
		}
	}
}
