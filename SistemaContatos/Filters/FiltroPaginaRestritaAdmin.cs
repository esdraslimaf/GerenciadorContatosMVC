using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using SistemaContatos.Models;

namespace SistemaContatos.Filters
{
    public class FiltroPaginaRestritaAdmin : ActionFilterAttribute
    {
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			string sessao = context.HttpContext.Session.GetString("sessaoUsuarioLogado");
			if (string.IsNullOrEmpty(sessao))
			{
				context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
			}
			else
			{
				Usuario usuario = JsonConvert.DeserializeObject<Usuario>(sessao);
				if (usuario == null)
				{
					context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
				}
                if (usuario.Perfil != Enums.PerfilEnum.Admin)
                {
					context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Restrito" }, { "action", "Index" } });
				}
			} 
			base.OnActionExecuting(context);
		}
	}
}
