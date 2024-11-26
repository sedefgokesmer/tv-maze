using Microsoft.EntityFrameworkCore;
using TVMazeScraper.Data;
using TVMazeScraper.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<TVMazeContext>(options =>
     options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHttpClient<TVMazeService>();

var app = builder.Build();

// Run scraper on startup

// Ran one time and created the database

// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;
//     var tvMazeService = services.GetRequiredService<TVMazeService>();
//     await tvMazeService.GetShowData();
// }

// Middleware
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();
app.MapControllers();
app.MapOpenApi();
app.Run();
