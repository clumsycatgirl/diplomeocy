using Microsoft.AspNetCore.Mvc;

namespace Web.Utils;

public static class ControllerExtension {
	public static JsonResult JsonNotFound(this Controller controller, string what)
		=> controller.Json(new { success = false, what = $"{what} not found" });

	public static JsonResult JsonRedirect(this Controller controller, string destination)
		=> controller.Json(new { success = true, destination });

	public static JsonResult JsonError(this Controller controller, params (string Field, string ErrorMessage)[] errors)
		=> controller.Json(new {
			success = false,
			errors = errors
				.Select(error => new {
					Field = error.Field,
					Errors = new List<string> { error.ErrorMessage }
				})
				.ToList()
		});

}
