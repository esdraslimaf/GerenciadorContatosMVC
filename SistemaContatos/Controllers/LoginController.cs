using Microsoft.AspNetCore.Mvc;
using SistemaContatos.Models;
using SistemaContatos.Repository.Interfaces;

namespace SistemaContatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _repo;
        public LoginController(IUsuarioRepository repo)
        {
            _repo = repo; 
        }

        public IActionResult Index()
        {
            return View();
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
  