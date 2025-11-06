using CatalogService.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura EF Core con SQLite
builder.Services.AddDbContext<CatalogContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("CatalogConnection")));

// Aggiunge controller
builder.Services.AddControllers();

var app = builder.Build();

// Crea il DB e applica il seed
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CatalogContext>();
    db.Database.EnsureDeleted(); // (solo per test, rimuovere in produzione)
    db.Database.EnsureCreated();
}

app.MapControllers();

app.Run();