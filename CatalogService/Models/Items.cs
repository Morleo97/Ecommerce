namespace CatalogService.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descrizione { get; set; } = string.Empty;
        public decimal Prezzo { get; set; }
        public int QuantitaDisponibile { get; set; }
    }
}