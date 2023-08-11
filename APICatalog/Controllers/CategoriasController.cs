using APICatalog.Database;
using APICatalog.Enum;
using APICatalog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalog.Controllers
{
    /// <summary>
    /// Controller responsável pelo gerenciamento das categorias.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriasController : ControllerBase
    {
        private readonly CatalogoDbContext _contexto;

        public CategoriasController(CatalogoDbContext contexto)
        {
            _contexto = contexto;
        }

        /// <summary>
        /// Obtém todas as categorias junto com seus produtos.
        /// </summary>
        /// <returns>Uma lista de categorias com seus produtos.</returns>
        /// <response code="200">Retorna a lista de categorias com seus respectivos produtos</response>
        /// <response code="404">Nenhuma categoria encontrada.</response>
        [HttpGet("produtos")]
        public IActionResult GetCategoriaProdutos()
        {
            var categorias = _contexto.Categorias.AsNoTracking().Include(p => p.Produtos);
            return Ok(categorias);
        }

        /// <summary>
        /// Obtém todas as categorias.
        /// </summary>
        /// <returns>Uma lista de categorias.</returns>
        /// <response code="200">Retorna a lista de categorias.</response>
        /// <response code="404">Nenhuma categoria foi encontrada.</response>
        [HttpGet]
        public IActionResult GetAll()
        {
            var categorias = _contexto.Categorias.AsNoTracking();
            return Ok(categorias);
        }

        /// <summary>
        /// Obtém uma categoria pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da categoria.</param>
        /// <returns>A categoria correspondente ao ID fornecido.</returns>
        /// <response code="200">Retorna a categoria solicitada.</response>
        /// <response code="404">Categoria não encontrada.</response>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var categorias = _contexto.Categorias.AsNoTracking().FirstOrDefault(p => p.CategoriaId == id);

            if(categorias is null)
            {
                return NotFound("Categoria não encontrada");
            }

            return Ok(categorias);
        }

        /// <summary>
        /// Cria uma nova categoria.
        /// </summary>
        /// <param name="categoria">Os dados da categoria.</param>
        /// <returns>A categoria recém-criada.</returns>
        /// <response code="201">Retorna a categoria criada.</response>
        /// <response code="400">Requisição inválida.</response>
        [HttpPost]
        public IActionResult Post(Categoria categoria)
        {
            if (categoria == null)
            {
                return BadRequest();
            }

            _contexto.Categorias.Add(categoria);
            _contexto.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = categoria.CategoriaId }, categoria);
        }

        /// <summary>
        /// Atualiza uma categoria existente.
        /// </summary>
        /// <param name="id">O ID da categoria a ser atualizada.</param>
        /// <param name="categoria">Os novos dados da categoria.</param>
        /// <returns>A categoria atualizada.</returns>
        /// <response code="200">Retorna a categoria atualizada.</response>
        /// <response code="400">Requisição inválida.</response>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Categoria categoria)
        {

            if (id != categoria.CategoriaId)
            {
                return BadRequest();
            }

            _contexto.Entry(categoria).State = EntityState.Modified;
            _contexto.SaveChanges();

            return Ok(categoria);
        }

        /// <summary>
        /// Exclui uma categoria pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da categoria a ser excluída.</param>
        /// <returns>Status sem conteúdo.</returns>
        /// <response code="204">Produto excluído com sucesso.</response>
        /// <response code="400">Requisição inválida.</response>
        /// <response code="404">Produto não encontrado.</response> 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var categorias = _contexto.Categorias.FirstOrDefault(p => p.CategoriaId == id);

            if (categorias is null)
            {
                return NotFound("Categoria não encontrada");
            }

            if (categorias.Situacao == Situacao.Ativo)
            {
                return BadRequest("A categoria está ativa e não pode ser excluída");
            }

            _contexto.Categorias.Remove(categorias);
            _contexto.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// Filtra categorias pelo nome.
        /// </summary>
        /// <param name="nome">O nome da categoria.</param>
        /// <returns>Uma lista de categorias filtradas.</returns>
        /// <response code="200">Retorna as categorias com a filtragem do nome.</response>
        /// <response code="400">O nome da categoria precisa ser válido.</response>
        [HttpGet("nome-categoria")]
        public IActionResult FiltrarPorNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                return BadRequest("Nome necessário para a filtragem");
            }

            var categorias = _contexto.Categorias
                .AsNoTracking()
                .Where(c => c.CategoriaNome.Contains(nome))
                .ToList();

            return Ok(categorias);
        }


        /// <summary>
        /// Filtra categorias por situação.
        /// </summary>
        /// <param name="situacao">A situação da categoria (ex. Ativo, Inativo).</param>
        /// <returns>Uma lista de categorias filtradas.</returns>
        /// <response code="200">Retorna as categorias com a situação especificada.</response>
        /// <response code="400">A situação da categoria precisa ser válida.</response>
        /// <response code="404">Categoria não encontrada com a situação especificada.</response>
        [HttpGet("situacao-categoria")]
        public IActionResult FiltrarPorSituacao(string situacao)
        {
            if (string.IsNullOrEmpty(situacao) || !Situacao.TryParse<Situacao>(situacao, ignoreCase: true, out Situacao situacaoEnum))
            {
                return BadRequest("A situação da categoria precisa ser válida");
            }

            var categorias = _contexto.Categorias
                .AsNoTracking()
                .Where(c => c.Situacao == situacaoEnum)
                .ToList();

            return Ok(categorias);
        }

    }

}
