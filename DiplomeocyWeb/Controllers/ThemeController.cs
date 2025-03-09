using Diplomeocy.Database.Services;

using Microsoft.AspNetCore.Mvc;

namespace Diplomeocy.Web.Controllers;
public class ThemeController : Controller {
	private readonly ILogger<ThemeController> logger;
	private readonly UserService userService;

	public ThemeController(ILogger<ThemeController> logger, UserService userService) {
		this.logger = logger;
		this.userService = userService;
	}

	[HttpGet("/Theme")]
	public void Index(string theme = "light") {
		//HttpContext.Session.Set("theme", Encoding.UTF8.GetBytes(theme));
		userService.RequireAuthentication();
		//userService.CurrentUser!.Theme = Enum.Parse<Theme>(theme, true);
	}
}
