using APICatalog.Enum;
using APICatalog.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalog.Database;

    public class CatalogoDbContext : DbContext
    {
        public CatalogoDbContext(DbContextOptions<CatalogoDbContext> options) : base(options)
        { }
         

        public DbSet<Categoria>? Categorias{ get; set; }
        public DbSet<Produto>? Produtos{ get; set; }

        public void SeedData()
        {
            
            for (int i = 1; i <= 5; i++)
            {
                Categorias.Add(new Categoria
                {
                    CategoriaId = i,
                    CategoriaNome = "Categoria " + i,
                    UrlImagem = "url/to/image" + i,
                    Situacao = Situacao.Ativo
                });
            }

      
            for (int i = 1; i <= 15; i++)
            {
                Produtos.Add(new Produto
                {
                    ProdutoId = i,
                    ProdutoNome = "Produto " + i,
                    ProdutoDescricao = "Descrição do Produto " + i,
                    ProdutoPreco = 10.5m * i,
                    UrlImagem = "url/to/product/image" + i,
                    Quantidade = 5 * i,
                    DataRegistro = DateTime.Now,
                    CategoriaId = (i % 5) + 1,
                    Situacao = Situacao.Ativo
                });
            }

            SaveChanges();
        }

}
