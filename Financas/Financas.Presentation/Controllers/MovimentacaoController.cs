using Financas.Application.Service;
using Financas.Domain;
using Financas.Infrastructure.DependencyInjection;
using Financas.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Financas.Presentation.Controllers
{
    public class MovimentacaoController : Controller
    {
        private readonly IApplicationManager _applicationManager = CompositionRoot.Resolve<IApplicationManager>();

        #region Action

        public ActionResult Index()
        {
            var movimentacoes = _applicationManager.MovimentacaoService.ListarTodas();
            var movimentacoesViewModel = TransformarListaMovimentacoesParaListaViewModel(movimentacoes);

            return View(movimentacoesViewModel);
        }

        public ActionResult Form()
        {
            ViewBag.Usuarios = _applicationManager.UsuarioService.ListarTodos();
            return View();
        }

        public ActionResult Cadastro(MovimentacaoViewModel mvm)
        {
            if (ModelState.IsValid)
            {
                var movimentacao = TransformarViewModelParaMovimentacao(mvm);
                _applicationManager.MovimentacaoService.Adicionar(movimentacao);

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Usuarios = _applicationManager.UsuarioService.ListarTodos();
                return RedirectToAction("Form", mvm);
            }
        }

        #endregion

        #region Metodos

        private MovimentacaoViewModel TransformarMovimentacaoParaViewModel(Movimentacao movimentacao)
        {
            return new MovimentacaoViewModel()
            {
                Tipo = movimentacao.Tipo,
                Data = movimentacao.Data,
                Usuario = movimentacao.Usuario,
                Valor = movimentacao.Valor
            };
        }

        private Movimentacao TransformarViewModelParaMovimentacao(MovimentacaoViewModel mvm)
        {
            return new Movimentacao()
            {
                Tipo = mvm.Tipo,
                Data = mvm.Data,
                Usuario = mvm.Usuario,
                Valor = mvm.Valor
            };
        }

        private ICollection<MovimentacaoViewModel> TransformarListaMovimentacoesParaListaViewModel(ICollection<Movimentacao> movimentacoes)
        {
            var listaViewModel = new List<MovimentacaoViewModel>();

            foreach (var movimentacao in movimentacoes)
            {
                listaViewModel.Add(
                    new MovimentacaoViewModel()
                    {
                        Tipo = movimentacao.Tipo,
                        Data = movimentacao.Data,
                        Usuario = movimentacao.Usuario,
                        Valor = movimentacao.Valor
                    });
            }
            return listaViewModel;
        }

        #endregion

    }
}