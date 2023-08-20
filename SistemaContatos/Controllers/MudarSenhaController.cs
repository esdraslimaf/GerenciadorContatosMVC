using Microsoft.AspNetCore.Mvc;
using SistemaContatos.Helper;
using SistemaContatos.Models;
using SistemaContatos.Repository.Interfaces;

namespace SistemaContatos.Controllers
{
    public class MudarSenhaController : Controller
    {
        private readonly IUsuarioRepository _repo;
        private readonly ISessao _sessao;
        public MudarSenhaController(IUsuarioRepository repo,ISessao sessao)
        {
            _repo = repo;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(MudarSenha mudarSenhaModel)
        {
            try
            {
                Usuario usuarioLogado = _sessao.BuscarSessaoUsuario();
                mudarSenhaModel.Id = usuarioLogado.Id;

                if (ModelState.IsValid)
                {
                    _repo.AlterarSenha(mudarSenhaModel);
                    TempData["Sucesso"] = "Senha alterada com sucesso!";
                    return View("Index", mudarSenhaModel);
                }
                else
                {
                    return View("Index", mudarSenhaModel);
                }
            }
            catch (Exception erro)
            {
                TempData["Erro"] = "Problema ao tentar alterar a senha. Tente novamente! Detalhes: "+erro.Message;
                return View("Index", mudarSenhaModel);
            }
        }
    }
}
