using Backend;

using Microsoft.EntityFrameworkCore;

class Program {
	static void Main(string[] args) {
		WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

		// Add services to the container.

		// add setup for mysql server
		if (builder.Configuration.GetConnectionString("DefaultConnection") is string connectionString)
			builder.Services.AddDbContext<DatabaseContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
		else {
			Console.Error.WriteLine("No connection string found");
		}

		builder.Services.AddControllers();
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();
		builder.Services.AddSignalR();

		WebApplication app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment()) {
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}
}
