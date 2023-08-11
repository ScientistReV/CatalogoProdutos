using APICatalog.Models;

namespace APICatalog.Repositorios
{
    public class UsuarioRepositorio
    {
        public static UsuarioAutenticacao GetUsuarioAutenticacao(string usuarioNome, string usuarioSenha)
        {
            var usuarios = new List<UsuarioAutenticacao>
            {
                new () { UsuarioId = 1, UsuarioNome = "batman", UsuarioSenha = "123456", Papel = "gerente" },
                new () { UsuarioId = 2, UsuarioNome = "robin", UsuarioSenha = "123456", Papel = "empregado" }
            };

            return usuarios.FirstOrDefault(u => u.UsuarioNome == usuarioNome && u.UsuarioSenha == usuarioSenha);
        }
    }
}
