using System.Diagnostics;

using Frontend.Models;

using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers;
public class HomeController : Controller {
	private readonly ILogger<HomeController> logger;
	private readonly HttpClient httpClient;

	public HomeController(ILogger<HomeController> logger, HttpClient httpClient) {
		this.logger = logger;
		this.httpClient = httpClient;
	}

	public IActionResult Index() {
		return View();
	}

	public IActionResult Privacy() {
		return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error() {
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}
