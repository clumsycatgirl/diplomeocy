using System.Diagnostics;

using Diplomeocy.Web.Models;

using Microsoft.AspNetCore.Mvc;

namespace Diplomeocy.Web.Controllers;
public class ErrorController : Controller {
	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Index() {
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}
