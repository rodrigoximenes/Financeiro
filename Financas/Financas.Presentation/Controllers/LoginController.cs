using System.Web.Mvc;
using WebMatrix.WebData;

namespace Financas.Presentation.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autenticar(string login, string senha)
        {
            if (WebSecurity.Login(login, senha))
            {
                return RedirectToAction("Index", "Movimentacao");
            }
            else
            {
                ModelState.AddModelError("login.Invalido", "Login ou senha incorretos");
                return View("Index");
            }
        }

        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index");
        }
    }
}