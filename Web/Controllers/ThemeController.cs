using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers {
	[Route("[controller]")]
	public class ThemeController : Controller {
		[HttpGet("")]
		public void Index(string theme = "light") {
			System.Diagnostics.Debug.WriteLine($"setting theme to '{theme}'");
			HttpContext.Session.Set("Theme", Encoding.UTF8.GetBytes(theme));
		}
	}
}