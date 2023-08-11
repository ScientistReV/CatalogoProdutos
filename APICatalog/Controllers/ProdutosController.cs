using APICatalog.Database;
using APICatalog.Enum;
using APICatalog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalog.Controllers
{
    /// <summary>
    /// Controller para gerenciar produtos.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ProdutosController : ControllerBase
    {
        private readonly CatalogoDbContext _contexto;

        public ProdutosController(CatalogoDbContext contexto)
        {
            _contexto = contexto;
        }

        /// <summary>
        /// Obtém todos os produtos.
        /// </summary>
        /// <returns>Uma lista de produtos.</returns>
        /// <response code="200">Retorna a lista de produtos.</response>
        /// <response code="404">Nenhum produto foi encontrado.</response>
        [HttpGet]

        public IActionResult Get()
        {
            var result = _contexto.Produtos.AsNoTracking();
            
            if( result is null)
            {
                return NotFound("Produtos não encontrado");
            }

            return Ok(result);
        }

        /// <summary>
        /// Obtém um produto por ID.
        /// </summary>
        /// <param name="id">O ID do produto.</param>
        /// <returns>O produto solicitado.</returns>
        /// <response code="200">Retorna o produto solicitado.</response>
        /// <response code="404">Produto não encontrado.</response>
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var result = _contexto.Produtos.AsNoTracking().SingleOrDefault(p => p.ProdutoId == id);

            if (result is null)
            {
                return NotFound("Produto não encontrado");
            }

            return Ok(result);
        }

        /// <summary>
        /// Cria um novo produto.
        /// </summary>
        /// <param name="produto">O objeto do produto.</param>
        /// <returns>O produto criado.</returns>
        /// <response code="201">Retorna o produto criado.</response>
        /// <response code="400">Requisição inválida.</response>
        [HttpPost]

        public IActionResult Post(Produto produto)
        {
            if (produto == null)
            {
                return BadRequest();
            }

            _contexto.Produtos.Add(produto);
            _contexto.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = produto.ProdutoId }, produto);
        }

        /// <summary>
        /// Atualiza um produto existente.
        /// </summary>
        /// <param name="produto">O objeto atualizado do produto.</param>
        /// <param name="id">O ID do produto a ser atualizado.</param>
        /// <returns>O produto atualizado.</returns>
        /// <response code="200">Retorna o produto atualizado.</response>
        /// <response code="400">Requisição inválida.</response>
        [HttpPut("{id}")]

        public IActionResult Put(Produto produto, int id)
        {

            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _contexto.Entry(produto).State = EntityState.Modified;
            _contexto.SaveChanges();

            return Ok(produto);

        }

        /// <summary>
        /// Exclui um produto por ID.
        /// </summary>
        /// <param name="id">O ID do produto a ser excluído.</param>
        /// <response code="204">Produto excluído com sucesso.</response>
        /// <response code="404">Produto não encontrado.</response>
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var result = _contexto.Produtos.SingleOrDefault(p => p.ProdutoId == id);

            if (result == null)
            {
                return NotFound("Produto não encontrado");
            }

            _contexto.Produtos.Remove(result);
            _contexto.SaveChanges();

            return NoContent();
        }
        /// <summary>
        /// Obtém produtos por categoria.
        /// </summary>
        /// <param name="categoriaId">O ID da categoria.</param>
        /// <returns>Produtos da categoria especificada.</returns>
        /// <response code="200">Retorna os produtos da categoria especificada.</response>
        /// <response code="404">Produto não encontrado para a categoria especificada.</response>
        [HttpGet("categoria/{categoriaId}")]
        public IActionResult GetByCategoria(int categoriaId)
        {
            var produtos = _contexto.Produtos.AsNoTracking()
                           .Where(p => p.CategoriaId == categoriaId)
                           .ToList();

            if (!produtos.Any())
            {
                return NotFound("Produtos não encontrados para a categoria especificada");
            }

            return Ok(produtos);
        }

        /// <summary>
        /// Obtém produtos por descrição.
        /// </summary>
        /// <param name="descricao">A descrição do produto.</param>
        /// <returns>Produtos que correspondem à descrição especificada.</returns>
        /// <response code="200">Retorna os produtos com a descrição especificada.</response>
        /// <response code="404">Produto não encontrado com a descrição especificada.</response>
        [HttpGet("descricao")]
        public IActionResult GetByDescricao(string descricao)
        {
            var produtos = _contexto.Produtos.AsNoTracking()
                           .Where(p => p.ProdutoDescricao.Contains(descricao))
                           .ToList();

            if (!produtos.Any())
            {
                return NotFound("Produtos não encontrados com a descrição especificada");
            }

            return Ok(produtos);
        }

        /// <summary>
        /// Obtém produtos por situação.
        /// </summary>
        /// <param name="situacao">A situação do produto (Ativo/Inativo).</param>
        /// <returns>Produtos que correspondem à situação especificada.</returns>
        /// <response code="200">Retorna os produtos com a situação especificada.</response>
        /// <response code="400">A situação do produto precisa ser válida.</response>
        /// <response code="404">Produto não encontrado com a situação especificada.</response>
        [HttpGet("situacao-produto/{situacao}")]
        public IActionResult GetBySituacao(string situacao)
        {
            if (!Situacao.TryParse<Situacao>(situacao, ignoreCase: true, out Situacao situacaoEnum))
            {
                return BadRequest("A situação dos produtos precisa ser válido");
            }

            var produtos = _contexto.Produtos.AsNoTracking()
                           .Where(p => p.Situacao == situacaoEnum)
                           .ToList();

            if (!produtos.Any())
            {
                return NotFound("Produtos não encontrados com a situação especificada");
            }

            return Ok(produtos);
        }

    }
}
