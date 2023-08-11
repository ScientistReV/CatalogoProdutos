using APICatalog.Models;
using APICatalog.Repositorios;
using APICatalog.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICatalog.Controllers
{
    [ApiController]
    [Route("v1")]
    public class AutenticacaoController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] UsuarioAutenticacao model)
        {
            var usuario = UsuarioRepositorio.GetUsuarioAutenticacao(model.UsuarioNome, model.UsuarioSenha);

            if (usuario is null)
            {
                return NotFound(new { message = "Usuário ou senha inválidos" });
            }

            var token = TokenService.GerarToken(usuario);
            usuario.UsuarioSenha = "";

            return new
            {
                usuario = usuario,
                token = token
            };
        }
    }
}
