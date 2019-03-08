using Financas.Application.Service;
using Financas.Domain;
using Financas.Presentation.Models;
using System.Web.Mvc;

namespace Financas.Presentation.Controllers
{
    public class UsuarioController : Controller
    {
        private ApplicationManager _applicationService;

        public UsuarioController()
        {
            _applicationService = new ApplicationManager();
        }

        public ActionResult Index()
        {
            _applicationService.UsuarioRepository.Adicionar(new Usuario());
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