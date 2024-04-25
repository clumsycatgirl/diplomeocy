using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;
public class MeowController : Controller {
	public IActionResult Index() {
		return View();
	}
}
