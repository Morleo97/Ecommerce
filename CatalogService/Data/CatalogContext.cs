using Microsoft.EntityFrameworkCore;
using CatalogService.Models;

namespace CatalogService.Data
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options) { }

        public DbSet<Item> Items => Set<Item>();

        // Dati iniziali (seed)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Nome = "Maglietta", Descrizione = "Maglietta cotone 100%", Prezzo = 19.99m, QuantitaDisponibile = 50 },
                new Item { Id = 2, Nome = "Scarpe", Descrizione = "Scarpe sportive", Prezzo = 59.99m, QuantitaDisponibile = 20 },
                new Item { Id = 3, Nome = "Zaino", Descrizione = "Zaino da viaggio", Prezzo = 39.99m, QuantitaDisponibile = 15 }
            );
        }
    }
}