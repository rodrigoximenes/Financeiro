using Financas.Presentation.Models;
using System.Web.Mvc;

namespace Financas.Presentation.Controllers
{
    public class UsuarioController : Controller
    {
        public UsuarioController()
        {
           
        }

        public ActionResult Index()
        {
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
                //Adicionar usuario via Serviço
                return RedirectToAction("Index");
            }
            else
            {
                return View("Form", usuarioView);
            }
        }
    }
}