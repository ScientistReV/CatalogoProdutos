using APICatalog.Database;
using APICatalog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CatalogDbContext _context;

        public CategoriesController(CatalogDbContext context)
        {
            _context = context;
        }

        [HttpGet("products")]
        public IActionResult GetCategoryProducts()
        {
            var categories = _context.Categories.AsNoTracking().Include(p => p.Products);
            return Ok(categories);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _context.Categories.AsNoTracking();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var categories = _context.Categories.AsNoTracking().FirstOrDefault(p => p.CategoryId == id);

            if(categories is null)
            {
                return NotFound("Category not found");
            }

            return Ok(categories);
        }

        [HttpPost]
        public IActionResult Post(Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            _context.Categories.Add(category);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = category.CategoryId }, category);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Category category)
        {

            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(category);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var categories = _context.Categories.FirstOrDefault(p => p.CategoryId == id);

            if (categories is null)
            {
                return NotFound("Categories not found");
            }

            _context.Categories.Remove(categories);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
