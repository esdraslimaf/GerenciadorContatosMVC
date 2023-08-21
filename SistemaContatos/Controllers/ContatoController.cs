using Microsoft.AspNetCore.Mvc;
using SistemaContatos.Filters;
using SistemaContatos.Helper;
using SistemaContatos.Models;
using SistemaContatos.Repository.Interfaces;

namespace SistemaContatos.Controllers
{
    [PaginasDisponiveisPosLogin]
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _repo;
        private readonly ISessao _sessao;
        public ContatoController(IContatoRepository repo, ISessao sessao)
        {
            _repo = repo;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            List<Contato> Contatos = _repo.BuscarContatos(_sessao.BuscarSessaoUsuario().Id);
            return View(Contatos);
        }

        public IActionResult AdicionarContato()
        {
            return View();
        }

        public IActionResult EditarContato(int id)
        {
            try { 
            Contato Contato = _repo.BuscarContatoPorId(id);
                return View(Contato);
            }
            catch(Exception erro)
            {
                TempData["Erro"] = $"Ops! Algum erro ocorreu. Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult EditarContato(Contato contato)
        {
            if (ModelState.IsValid) { 
            contato.UsuarioId = _sessao.BuscarSessaoUsuario().Id;
            _repo.EditarContato(contato);
            TempData["Sucesso"] = "Contato editado com sucesso!";
            return RedirectToAction("Index");
            }
            return View(contato);
        }

        public IActionResult ExcluirContato(int id)
        {
            try { 
            return View(_repo.BuscarContatoPorId(id));
            }
            catch(Exception erro)
            {
                TempData["Erro"] = $"Ops! Algum erro ocorreu. Erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }

        public IActionResult ConfirmarExclusao(int id)
        {
            try { 
            _repo.ExcluirContato(id);
            TempData["Sucesso"] = "O contato foi deletado com sucesso!";
            return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["Erro"] = $"Ops! Algum erro ocorreu. Erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult AdicionarContato(Contato Contato)
        {       
                if (ModelState.IsValid)
                {
                    Contato.UsuarioId = _sessao.BuscarSessaoUsuario().Id;
                    _repo.AddContato(Contato);
                    TempData["Sucesso"] = "Contato adicionado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(Contato);
            }
    
        
    }
}
