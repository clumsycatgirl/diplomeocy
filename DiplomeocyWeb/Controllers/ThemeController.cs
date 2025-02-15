using System.Text;

using Microsoft.AspNetCore.Mvc;

namespace Diplomeocy.Web.Controllers;
[Route("[controller]")]
public class ThemeController : Controller {
	[HttpGet("")]
	public void Index(string theme = "light") {
		System.Diagnostics.Debug.WriteLine("meow");
		HttpContext.Session.Set("theme", Encoding.UTF8.GetBytes(theme));
	}
}
