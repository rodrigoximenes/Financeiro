using Financas.Application.Service;
using Financas.Domain;
using Financas.Infrastructure.DependencyInjection;
using Financas.Presentation.Models;
using System.Web.Mvc;

namespace Financas.Presentation.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IApplicationManager _applicationManager = CompositionRoot.Resolve<IApplicationManager>();

        public UsuarioController() { }

        public ActionResult Index()
        {
            _applicationManager.UsuarioService.Adicionar(new Usuario());
            return View();
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Cadastro(UsuarioViewModel usuarioView)
        {
            if (ModelState.IsValid)
            {
                
                return RedirectToAction("Index");
            }
            else
            {
                return View("Form", usuarioView);
            }
        }
    }
}