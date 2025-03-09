using Diplomeocy.Database;
using Diplomeocy.Database.Models;
using Diplomeocy.Database.Services;
using Diplomeocy.Extensions;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Diplomeocy.Web.Controllers;
public class AuthController : Controller {
	private readonly ILogger<AuthController> logger;
	private readonly DatabaseContext context;
	private readonly UserService userService;

	public AuthController(ILogger<AuthController> logger, DatabaseContext context, UserService userService) {
		this.context = context;
		this.userService = userService;
		this.logger = logger;
	}

	[HttpGet]
	[Route("Auth")]
	public IActionResult Index() => View();

	[HttpPost]
	[Route("Auth/Login")]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Login(string? username, string? password) {
		List<(string Field, string ErrorMessage)> errors = new();

		if (username is null) {
			errors.Add(("username", "Username is required"));
		}

		if (password is null) {
			errors.Add(("password", "Password is required"));
		}

		if (context.Users is null) {
			errors.Add(("context", "Missing context"));
		}

		if (errors.Count != 0)
			return this.JsonError([.. errors]);

		string hashed = Encryption.GetHashString(password!);
		User? user = await context.Users!.FirstOrDefaultAsync(m => m.Username == username && m.Password == hashed);
		userService.SetUser(user);

		if (user is not null) {
			HttpContext.Session.Remove("Theme");
		}

		return user is null
			? await context.Users!.FirstOrDefaultAsync(u => u.Username == username) is not null
				? this.JsonError(("password", "Invalid password"))
				: (IActionResult)this.JsonNotFound("user")
			: this.JsonRedirect("/");
	}

	[HttpPost]
	[Route("Auth/Register")]
	public async Task<IActionResult> Register(string? username, string? password, string? passwordConfirmation, string? picturePath) {
		List<(string Field, string ErrorMessage)> errors = [];

		if (string.IsNullOrEmpty(username)) {
			errors.Add(("username", "Username is required"));
		} else {
			User? existingUser = await context.Users.FirstOrDefaultAsync(user => user.Username == username);
			if (existingUser is not null) {
				errors.Add(("username", "User already registered"));
			}
		}
		if (string.IsNullOrEmpty(password)) {
			errors.Add(("password", "Password is required"));
		}
		if (string.IsNullOrEmpty(passwordConfirmation)) {
			errors.Add(("passwordConfirmation", "Password confirmation is required"));
		}
		if (password is not null && passwordConfirmation is not null && password != passwordConfirmation) {
			errors.Add(("passwordConfirmation", "Passwords do not match"));
		}

		if (errors.Any()) {
			return this.JsonError(errors.ToArray());
		}

		User user = new User {
			Username = username!,
			Password = Encryption.GetHashString(password!),
			PathImage = picturePath!
		};
		context.Users.Add(user);
		await context.SaveChangesAsync();

		return await Login(username, password);
	}

	[HttpGet]
	[Route("Auth/LogOut")]
	public IActionResult LogOut() {
		userService.SetUser(null);
		HttpContext.Session.Clear();
		return RedirectToAction("Index", "Home");
	}
}
