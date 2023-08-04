using Newtonsoft.Json;
using SistemaContatos.Models;

namespace SistemaContatos.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;
        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;        
        }
        public Usuario BuscarSessaoUsuario() // Retorna a sessão objeto de Json transformada em Objeto
        {
            //Buscar o usuário logado
            string usuarioSessao = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");
            if (string.IsNullOrEmpty(usuarioSessao)) return null;
            return JsonConvert.DeserializeObject<Usuario>(usuarioSessao);
        }

        public void CriarSessaoUsuario(Usuario usuario) // Cria a sessão transformando o Objeto em Json
        {
            //Esse método é para a sessão no login
            string usuarioJson = JsonConvert.SerializeObject(usuario);
            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", usuarioJson);
        }

        public void RemoverSessaoUsuario()
        {
            //Esse métodod é para deslogar
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
