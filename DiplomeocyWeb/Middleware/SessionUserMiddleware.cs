
using Diplomeocy.Database.Models;
using Diplomeocy.Extensions;

public class SessionUserMiddleware {
	private readonly RequestDelegate next;
	private readonly ILogger<SessionUserMiddleware> logger;
	private readonly IHttpContextAccessor httpContextAccessor;

	public SessionUserMiddleware(RequestDelegate next, ILogger<SessionUserMiddleware> logger, IHttpContextAccessor httpContextAccessor) {
		this.next = next;
		this.logger = logger;
		this.httpContextAccessor = httpContextAccessor;
	}

	public async Task InvokeAsync(HttpContext httpContext) {
		string session = "\n";
		foreach (string key in httpContextAccessor.HttpContext?.Session.Keys ?? Enumerable.Empty<string>()) {
			string value = key switch {
				"CurrentUser" => Newtonsoft.Json.JsonConvert.SerializeObject(httpContext!.Session!.Get<User>(key)!)!,
				_ => httpContextAccessor.HttpContext!.Session!.Get(key)!.ToString()!,
			};
			session += $"\t{key} = {value}\n";
		}
		logger.LogInformation($"Session: {session}");

		await next(httpContext);
	}
}
