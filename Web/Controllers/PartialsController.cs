using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Web.Controllers {
	[Route("partial")]
	public class PartialsController : Controller {
		private readonly ILogger<PartialsController> logger;

		public PartialsController(ILogger<PartialsController> logger) {
			this.logger = logger;
		}


	}
}