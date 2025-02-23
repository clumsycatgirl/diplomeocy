using System.Text;

using Microsoft.AspNetCore.Mvc;

namespace Diplomeocy.Web.Controllers;
public class ThemeController : Controller {
	private readonly ILogger<ThemeController> logger;

	public ThemeController(ILogger<ThemeController> logger) {
		this.logger = logger;
	}

	[HttpGet("/Theme")]
	public void Index(string theme = "light") {
		HttpContext.Session.Set("theme", Encoding.UTF8.GetBytes(theme));
	}
}
