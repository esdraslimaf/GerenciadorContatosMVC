using Microsoft.AspNetCore.Mvc;
using SistemaContatos.Models;
using SistemaContatos.Repository.Interfaces;

namespace SistemaContatos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _repo;
        public UsuarioController(IUsuarioRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            List<Usuario> Usuarios = _repo.BuscarUsuarios();
            return View(Usuarios);
        }

        public IActionResult AdicionarUsuario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdicionarUsuario(Usuario Usuario)
        {
            if (ModelState.IsValid)
            {
                _repo.AddUsuario(Usuario);
                TempData["Sucesso"] = "Usuario adicionado com sucesso!";
                return RedirectToAction("Index");
            }
            return View(Usuario);
        }
    }
}
