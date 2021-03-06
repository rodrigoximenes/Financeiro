﻿using Financas.Application.Service;
using Financas.Domain;
using Financas.Infrastructure.DependencyInjection;
using Financas.Presentation.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Financas.Presentation.Controllers
{
    [Authorize]
    public class MovimentacaoController : Controller
    {
        private readonly IApplicationManager _applicationManager = CompositionRoot.Resolve<IApplicationManager>();

        #region Action

        public ActionResult Index()
        {
            var movimentacoes = _applicationManager.MovimentacaoService.ListarTodas();
            var movimentacoesViewModel = TransformarListaMovimentacoesParaListaViewModel(movimentacoes as IList<Movimentacao>);

            return View(movimentacoesViewModel as IList<MovimentacaoModel>);
        }

        public ActionResult Form()
        {
            ViewBag.Usuarios = _applicationManager.UsuarioService.ListarTodos();
            return View();
        }

        public ActionResult Cadastro(MovimentacaoModel mvm)
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

        public ActionResult MovimentacoesPorUsuario(MovimentacoesPorUsuarioModel model)
        {
            model.Usuarios = _applicationManager.UsuarioService.ListarTodos() as IList<Usuario>;
            model.Movimentacoes = _applicationManager.MovimentacaoService.BuscarPorUsuario(model.UsuarioId) as IList<Movimentacao>;

            return View(model);
        }

        public ActionResult Busca(BuscaMovimentacoesModel model)
        {
            model.Usuarios = _applicationManager.UsuarioService.ListarTodos() as IList<Usuario>;
            model.Movimentacoes = _applicationManager.MovimentacaoService.
                Buscar(model.ValorMinimo, model.ValorMaximo,
                       model.DataMinima, model.DataMaxima,
                       model.Tipo, model.UsuarioId) as IList<Movimentacao>;

            return View(model);
        }

        #endregion

        #region Metodos

        private MovimentacaoModel TransformarMovimentacaoParaViewModel(Movimentacao movimentacao)
        {
            return new MovimentacaoModel()
            {
                Tipo = movimentacao.Tipo,
                Data = movimentacao.Data,
                Valor = movimentacao.Valor,
                Usuario = movimentacao.Usuario,
                UsuarioId = movimentacao.UsuarioId
            };
        }

        private Movimentacao TransformarViewModelParaMovimentacao(MovimentacaoModel mvm)
        {
            return new Movimentacao()
            {
                Tipo = mvm.Tipo,
                Data = mvm.Data,
                Valor = mvm.Valor,
                Usuario = mvm.Usuario,
                UsuarioId = mvm.UsuarioId
            };
        }

        private ICollection<MovimentacaoModel> TransformarListaMovimentacoesParaListaViewModel(ICollection<Movimentacao> movimentacoes)
        {
            var listaViewModel = new List<MovimentacaoModel>();

            foreach (var movimentacao in movimentacoes)
            {
                listaViewModel.Add(
                    new MovimentacaoModel()
                    {
                        Tipo = movimentacao.Tipo,
                        Data = movimentacao.Data,
                        Valor = movimentacao.Valor,
                        Usuario = movimentacao.Usuario,
                        UsuarioId = movimentacao.UsuarioId
                    });
            }
            return listaViewModel;
        }

        #endregion

    }
}