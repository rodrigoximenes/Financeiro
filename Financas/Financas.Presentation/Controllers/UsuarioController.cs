using Financas.Application.Service;
using Financas.Domain;
using Financas.Infrastructure.DependencyInjection;
using Financas.Presentation.Models;
using System.Web.Mvc;
using System.Collections.Generic;
using WebMatrix.WebData;
using System.Web.Security;

namespace Financas.Presentation.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IApplicationManager _applicationManager = CompositionRoot.Resolve<IApplicationManager>();

        public UsuarioController() { }

        #region Actions

        public ActionResult Index()
        {
            var usuarios = _applicationManager.UsuarioService.ListarTodos();
            var usuariosViewModel = TransformarListaUsuarioParaListaViewModel(usuarios);

            return View(usuariosViewModel);
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Cadastro(UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //var usuario = TransformarViewModelParaUsuario(usuarioModel);

                    //_applicationManager.UsuarioService.Adicionar(usuario);

                    //WebSecurity.CreateAccount(usuarioModel.Nome, usuarioModel.Senha);

                    WebSecurity.CreateUserAndAccount(usuarioModel.Nome, usuarioModel.Senha, 
                        new { Email = usuarioModel.Email });

                    return RedirectToAction("Index");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("Usuario Invalido", e);
                    return View("Form", usuarioModel);
                }
            }
            else
            {
                return View("Form", usuarioModel);
            }
        }

        #endregion

        #region Métodos

        private ICollection<UsuarioModel> TransformarListaUsuarioParaListaViewModel(ICollection<Usuario> usuarios)
        {
            var listaViewModel = new List<UsuarioModel>();

            foreach (var usuario in usuarios)
            {
                listaViewModel.Add(
                    new UsuarioModel()
                    {
                        Nome = usuario.Nome,
                        Email = usuario.Email
                    });
            }
            return listaViewModel;
        }

        private Usuario TransformarViewModelParaUsuario(UsuarioModel usuarioModel)
        {
            return new Usuario()
            {
                Nome = usuarioModel.Nome,
                Email = usuarioModel.Email
            };
        }

        private UsuarioModel TransformarUsuarioParaViewModel(Usuario usuario)
        {
            return new UsuarioModel()
            {
                Nome = usuario.Nome,
                Email = usuario.Email
            };
        }

        #endregion

    }
}