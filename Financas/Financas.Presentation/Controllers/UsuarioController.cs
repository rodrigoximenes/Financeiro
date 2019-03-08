using Financas.Application.Service;
using Financas.Domain;
using Financas.Presentation.Models;
using System.Web.Mvc;

namespace Financas.Presentation.Controllers
{
    public class UsuarioController : Controller
    {
        private ApplicationManager _applicationManager;

        public UsuarioController()
        {
            _applicationManager = new ApplicationManager();
        }

        public ActionResult Index()
        {
            _applicationManager.UsuarioService.Adicionar(new Usuario());
            //passar usuarios para listar 16:56
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