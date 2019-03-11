using System;
using System.Collections.Generic;
using Financas.Domain;
using Financas.Domain.Interface;
using Financas.Infrastructure.DependencyInjection;
using System.Linq;

namespace Financas.Application.Service
{
    public class MovimentacaoService : IMovimentacaoService
    {
        private readonly IMovimentacaoRepository _movimentacaoRepository = CompositionRoot.Resolve<IMovimentacaoRepository>();

        public void Adicionar(Movimentacao movimentacao)
        {
            _movimentacaoRepository.Add(movimentacao);
        }

        public IList<Movimentacao> Buscar(decimal? valorMinimo, decimal? valorMaximo, DateTime? dataMinima, DateTime? dataMaxima, TipoMovimentacao? tipo, int? usuarioId)
        {
            IEnumerable<Movimentacao> busca = _movimentacaoRepository.FindAll();

            if (valorMinimo.HasValue)
            {
                busca = busca.Where(m => m.Valor >= valorMinimo);
            }

            if (valorMaximo.HasValue)
            {
                busca = busca.Where(m => m.Valor <= valorMaximo);
            }

            if (dataMinima.HasValue)
            {
                busca = busca.Where(m => m.Data >= dataMinima);
            }

            if (dataMaxima.HasValue)
            {
                busca = busca.Where(m => m.Data <= dataMaxima);
            }

            if (tipo.HasValue)
            {
                busca = busca.Where(m => m.Tipo == tipo);
            }

            if (usuarioId.HasValue)
            {
                busca = busca.Where(m => m.UsuarioId == usuarioId);
            }

            return busca.ToList();
        }

        public IList<Movimentacao> BuscarPorUsuario(int usuarioId)
        {
            return _movimentacaoRepository.FindAll().Where(usuario => usuario.Id == usuarioId) as IList<Movimentacao>;
        }

        public ICollection<Movimentacao> ListarTodas()
        {
            return _movimentacaoRepository.FindAll();
        }
    }
}
