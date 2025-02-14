using Microsoft.AspNetCore.Mvc;

namespace DiplomeocyWeb.Controllers;
public class HomeController : Controller {
	private readonly ILogger<HomeController> _logger;

	public HomeController(ILogger<HomeController> logger) {
		_logger = logger;
	}

	[HttpGet("/")]
	public IActionResult Index() {
		return View();
	}
}
