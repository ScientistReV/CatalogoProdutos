using APICatalog.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalog.Database;

    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
        { }

        public DbSet<Category>? Categories{ get; set; }
        public DbSet<Product>? Products{ get; set; }
}

