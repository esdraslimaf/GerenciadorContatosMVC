using Microsoft.AspNetCore.Mvc;
using SistemaContatos.Filters;

namespace SistemaContatos.Controllers
{
    [PaginasDisponiveisPosLogin]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
