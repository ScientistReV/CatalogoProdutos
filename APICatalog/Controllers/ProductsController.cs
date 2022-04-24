using APICatalog.Database;
using APICatalog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly CatalogDbContext _context;

        public ProductsController(CatalogDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult Get()
        {
            var result = _context.Products.AsNoTracking();
            
            if( result is null)
            {
                return NotFound("Products not found");
            }

            return Ok(result);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var result = _context.Products.AsNoTracking().SingleOrDefault(p => p.ProductId == id);

            if (result is null)
            {
                return NotFound("Products not found");
            }

            return Ok(result);
        }

        [HttpPost]

        public IActionResult Post(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = product.ProductId }, product);
        }

        [HttpPut("{id}")]

        public IActionResult Put(Product product, int id)
        {

            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(product);

        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var result = _context.Products.SingleOrDefault(p => p.ProductId == id);

            if (result == null)
            {
                return NotFound("Products not found");
            }

            _context.Products.Remove(result);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
