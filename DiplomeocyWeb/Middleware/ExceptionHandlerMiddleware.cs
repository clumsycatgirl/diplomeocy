using System.Net;

using Diplomeocy.Web.Exceptions;

public class ExceptionHandlerMiddleware {
	private readonly RequestDelegate next;
	private readonly ILogger<ExceptionHandlerMiddleware> logger;

	public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger) {
		this.next = next;
		this.logger = logger;
	}

	public async Task InvokeAsync(HttpContext httpContext) {
		try {
			await next(httpContext);
		} catch (RedirectException redirectException) {
			logger.LogInformation($"Redirecting to {redirectException.RedirectUrl}");
			httpContext.Response.Redirect(redirectException.RedirectUrl);
		}
		// catch (Exception ex) {
		// 	logger.LogError(ex, "An unhandled exception has occurred.");
		// 	await HandleExceptionAsync(httpContext, ex);
		// }
	}

	private Task HandleExceptionAsync(HttpContext context, Exception exception) {
		context.Response.ContentType = "application/json";
		context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

		throw exception;
	}
}
