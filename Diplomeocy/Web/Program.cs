using Microsoft.EntityFrameworkCore;

using Web;
using Web.Hubs;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

// used for api requests to backend
builder.Services.AddScoped<HttpClient>();

// add setup for mysql server
if (builder.Configuration.GetConnectionString("DefaultConnection") is string connectionString)
	builder.Services.AddDbContext<DatabaseContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
else {
	Console.Error.WriteLine("No connection string found");
}

WebApplication app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapHub<ChatHub>("/chatHub");

app.Run();
