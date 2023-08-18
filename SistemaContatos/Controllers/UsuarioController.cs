using Microsoft.AspNetCore.Mvc;
using SistemaContatos.Filters;
using SistemaContatos.Models;
using SistemaContatos.Repository.Interfaces;

namespace SistemaContatos.Controllers
{
    [FiltroPaginaRestritaAdmin]
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
        public IActionResult EditarUsuario(UsuarioSemSenhaEdicao usuarioSemSenhaEdicao)
        {
            try { 
            Usuario usuario = null;
            if (ModelState.IsValid)
            {
                usuario = new Usuario()
                {
                    Id = usuarioSemSenhaEdicao.Id,
                    Nome = usuarioSemSenhaEdicao.Nome,
                    Email = usuarioSemSenhaEdicao.Email,
                    Login = usuarioSemSenhaEdicao.Login,
                    Perfil = usuarioSemSenhaEdicao.Perfil
                    //DataAtualizacao = DateTime.Now - Ja é atualizado no _repo.EditarUsuario
                };

                _repo.EditarUsuario(usuario);
                TempData["Sucesso"] = "Usuario editado com sucesso!";
                return RedirectToAction("Index");
            }
            return View(usuario);
        }
        catch(Exception erro)
            {
                TempData["Erro"] = $"Ocorreu um erro! Não foi possível atualizar o usuário. Detalhes: {erro.Message}";
                return RedirectToAction("Index");
            }
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
