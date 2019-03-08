using Financas.Application.Service;
using Financas.Domain;
using Financas.Infrastructure.DependencyInjection;
using Financas.Presentation.Models;
using System.Web.Mvc;
using System;
using System.Collections.Generic;

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

        public ActionResult Cadastro(UsuarioViewModel usuarioView)
        {
            if (ModelState.IsValid)
            {
                var usuario = TransformarViewModelParaUsuario(usuarioView);
                _applicationManager.UsuarioService.Adicionar(usuario);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Form", usuarioView);
            }
        }

        #endregion

        #region Métodos

        private ICollection<UsuarioViewModel> TransformarListaUsuarioParaListaViewModel(ICollection<Usuario> usuarios)
        {
            var listaViewModel = new List<UsuarioViewModel>();

            foreach (var usuario in usuarios)
            {
                listaViewModel.Add(
                    new UsuarioViewModel()
                    {
                        Nome = usuario.Nome,
                        Email = usuario.Email
                    });
            }
            return listaViewModel;
        }

        private Usuario TransformarViewModelParaUsuario(UsuarioViewModel usuarioView)
        {
            return new Usuario()
            {
                Nome = usuarioView.Nome,
                Email = usuarioView.Email
            };
        }

        private UsuarioViewModel TransformarUsuarioParaViewModel(Usuario usuario)
        {
            return new UsuarioViewModel()
            {
                Nome = usuario.Nome,
                Email = usuario.Email
            };
        }

        #endregion

    }
}