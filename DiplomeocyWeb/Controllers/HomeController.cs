using Diplomeocy.Database.Services;

using Microsoft.AspNetCore.Mvc;

namespace Diplomeocy.Web.Controllers;

public class HomeController : Controller {
	private readonly ILogger<HomeController> logger;
	private readonly UserService userService;

	public HomeController(ILogger<HomeController> logger, UserService userService) {
		this.logger = logger;
		this.userService = userService;
	}

	[HttpGet("/")]
	public IActionResult Index() {
		return View();
	}

	[HttpGet("/Meow")]
	public void Meow() {
		//userService.SetUser(new Database.Models.User {
		//	Id = 10,
		//	Username = "HatsuneMiku",
		//	Password = "806EC396527434CED7ED350A0E7F96EBCECED03C8BA3036E172DA0D3E51B10AF",
		//	PathImage = "/assets/images/kittators/Stalin.png",
		//});
		logger.LogInformation(userService.CurrentUser?.Username ?? "unknown");
	}
}
