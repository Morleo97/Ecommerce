using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatalogService.Data;
using CatalogService.Models;

namespace CatalogService.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly CatalogContext _context;

        public ItemsController(CatalogContext context)
        {
            _context = context;
        }

        // GET /items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            var items = await _context.Items.ToListAsync();
            return Ok(items);
        }

        // GET /items/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Item>> GetItemById(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
                return NotFound(new { messaggio = "Articolo non trovato" });

            return Ok(item);
        }
    }
}
