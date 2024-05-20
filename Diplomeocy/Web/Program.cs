using System.Runtime.CompilerServices;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Web;
using Web.Hubs;
using Web.Middleware;
using Web.VoiceChatServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

builder.Services.AddSession();

builder.Services.AddLogging(logging => {
	logging.SetMinimumLevel(LogLevel.Debug)
		.AddConsole()
		.AddDebug()
		.AddTraceSource("Information, ActivityTracing")
		.AddEventSourceLogger();
});

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

builder.Logging
	.ClearProviders()
	.AddConsole()
	.AddTraceSource("Information, ActivityTracing")
	.AddDebug()
	.AddDebug()
	.AddEventSourceLogger();

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

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<ChatHub>("/chat/text");

// VoiceChatService voiceChatService = new();
// #pragma warning disable CS4014
// Task.Run(() => voiceChatService.StartAsync());
// #pragma warning restore CS4014
// IHostApplicationLifetime lifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();
// lifetime.ApplicationStopping.Register(() => voiceChatService.Stop());

// app.UseWebSockets();
// app.Use(async (context, next) => await WebSocketMiddlerware.Execute(context, next));

app.Run();
