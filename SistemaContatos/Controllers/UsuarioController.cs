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

        public IActionResult EditarUsuario(int id)
        {
            try
            {
                Usuario Usuario = _repo.BuscarUsuarioPorId(id);
                return View(Usuario);
            }
            catch (Exception erro)
            {
                TempData["Erro"] = $"Ops! Algum erro ocorreu. Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult EditarUsuario(Usuario Usuario)
        {
            if (ModelState.IsValid)
            {
                _repo.EditarUsuario(Usuario);
                TempData["Sucesso"] = "Usuario editado com sucesso!";
                return RedirectToAction("Index");
            }
            return View(Usuario);
        }

        public IActionResult ExcluirUsuario(int id)
        {
            try
            {
                return View(_repo.BuscarUsuarioPorId(id));
            }
            catch (Exception erro)
            {
                TempData["Erro"] = $"Ops! Algum erro ocorreu. Erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        public IActionResult ConfirmarExclusao(int id)
        {
            try
            {
                _repo.ExcluirUsuario(id);
                TempData["Sucesso"] = "O Usuario foi deletado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["Erro"] = $"Ops! Algum erro ocorreu. Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
