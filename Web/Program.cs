using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;

using Web;
using Web.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddServerSideBlazor();

builder.Services.AddSignalR();

builder.Services.AddSession();

builder.Services.AddLogging((logging) =>
	logging.SetMinimumLevel(LogLevel.Debug)
		.AddConsole()
		.AddDebug()
		.AddTraceSource("Information, ActivityTracing")
		.AddEventSourceLogger()
);

// used for api requests to backend
builder.Services.AddScoped<HttpClient>();

// add setup for mysql server
if (builder.Configuration.GetConnectionString("DefaultConnection") is string connectionString)
	builder.Services.AddDbContext<DatabaseContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
else {
	Console.Error.WriteLine("No connection string found");
}

// setup swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.AddServerSideBlazor();

builder.Services.AddAntiforgery();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<IHtmlHelper, HtmlHelper>();

builder.Logging
	.ClearProviders()
	.AddConsole()
	.AddTraceSource("Information, ActivityTracing")
	.AddDebug()
	.AddDebug()
	.AddEventSourceLogger();

builder.Services.AddCors((options) =>
	options.AddPolicy("cors", (policy) =>
		policy.AllowAnyOrigin())
);

builder.Services.AddSingleton<Dictionary<string, Diplomacy.GameHandler>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
} else {
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseHttpLogging();

app.UseRouting();

app.UseAuthorization();

app.UseSession();
app.UseMiddleware<Web.Middleware.AuthMiddleware>();

app.UseCors("cors");

app.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
	name: "StartGame",
	pattern: "Players/StartGame/{id}",
	defaults: new { controller = "Players", action = "StartGame" });

app.MapControllers();
app.MapHub<ChatHub>("/chat/text");
app.MapHub<GameHub>("/hubs/game");
app.MapHub<TableHub>("/hubs/table");

app.MapBlazorHub();

app.Run();
