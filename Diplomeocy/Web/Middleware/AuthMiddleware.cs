
using Microsoft.AspNetCore.Http;

using System.Threading.Tasks;

using Web.Models;
using Web.Utils;

namespace Web.Middleware;

public class AuthMiddleware {
	private readonly RequestDelegate next;

	public AuthMiddleware(RequestDelegate next) {
		this.next = next;
	}

	public async Task InvokeAsync(HttpContext context) {
		string[] unprotectedRoutes = new[] { "/", "/auth", "/auth/login", "/auth/register", "/theme", "/rulebook", "/termsofservices", "/privacy", "/documentation" };
		string requestPath = context.Request.Path.Value?.ToLower() ?? "";

		if (unprotectedRoutes.Contains(requestPath)) {
			await next(context);
			return;
		}

		bool isAuthenticated = context.Session.Get<User>("User") is not null;

		if (isAuthenticated) {
			await next(context);
			return;
		}

		context.Response.Redirect("/");
	}
}
