using Microsoft.AspNetCore.Mvc;
using SistemaContatos.Helper;
using SistemaContatos.Models;
using SistemaContatos.Repository.Interfaces;

namespace SistemaContatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _repo;
        private readonly ISessao _sessao;
        public LoginController(IUsuarioRepository repo, ISessao sessao)
        {
            _repo = repo;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            if (_sessao.BuscarSessaoUsuario() != null) return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult Deslogar()
        {
            _sessao.RemoverSessaoUsuario();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RealizarLogin(Login conta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   Usuario userDb = _repo.BuscarUsuarioPorLogin(conta.NomeLogin);
                    if (userDb != null)
                    {
                        if (userDb.ValidaSenha(conta.Senha))
                        {
                            _sessao.CriarSessaoUsuario(userDb);
                            return RedirectToAction("Index", "Home");
                        }
                            TempData["Erro"] = "Senha inválida. Tente novamente!";
                        return View("Index");
                    }
                    TempData["Erro"] = "Dados inválidos. Tente novamente!";
                    
                }
                return View("Index", conta);
            }
            catch (Exception erro)
            {
                TempData["Erro"] = $"Infelizmente não foi possível fazer o seu login! Detalhes:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
  