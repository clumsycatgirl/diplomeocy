using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using Web.Models;

namespace Web.Controllers {
	public class HomeController : Controller {
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger) {
			_logger = logger;
		}

		public IActionResult Index() {
			return View();
		}

		[HttpGet]
		[Route("Privacy")]
		public string Privacy() {
			return nameof(Privacy);
		}

		[HttpGet]
		[Route("TermsOfServices")]
		public string TermsOfServices() {
			return nameof(TermsOfServices);
		}

		[HttpGet]
		[Route("Rulebook")]
		public string Rulebook() {
			return nameof(Rulebook);
		}

		[HttpGet]
		[Route("Documentation")]
		public string Documentation() {
			return nameof(Documentation);
		}

		public IActionResult Chat() => View();
		public IActionResult ChatVoice() => View();

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error() {
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
