using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddServerSideBlazor();
builder.Services.AddSignalR();
builder.Services.AddSession();

builder.Services.AddLogging((ILoggingBuilder logging) => {
	logging.SetMinimumLevel(LogLevel.Debug)
		.AddConsole()
		.AddDebug()
		.AddTraceSource("Information, ActivityTracing")
		.AddEventSourceLogger();
});
builder.Logging
	.ClearProviders()
	.AddConsole()
	.AddTraceSource("Information, ActivityTracing")
	.AddDebug()
	.AddEventSourceLogger();

builder.Services.AddScoped<HttpClient>();

if (builder.Configuration.GetConnectionString("DefaultConnection") is string connectionString) {
	builder.Services.AddDbContext<DiplomeocyWeb.Database.DatabaseContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
} else {
	Console.Error.WriteLine("No connection string found");
}

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAntiforgery();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<IHtmlHelper, HtmlHelper>();

builder.Services.AddCors((CorsOptions options) => {
	options.AddPolicy("cors", (policy) => policy.AllowAnyOrigin());
});

//builder.Services.AddDataProtection()
//	.SetApplicationName("Diplomeocy")
//	.PersistKeysToDbContext<DiplomeocyWeb.Database.DatabaseContext>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
} else {
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
//app.UseHttpLogging();
app.UseRouting();
//app.UseAuthorization();
//app.UseSession();
app.UseCors("cors");

app.MapControllers();
app.MapBlazorHub();

app.Run();
