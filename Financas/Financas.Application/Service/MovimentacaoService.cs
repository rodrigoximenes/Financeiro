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
            IList<Movimentacao> busca = _movimentacaoRepository.FindAll() as IList<Movimentacao>;

            if (valorMinimo.HasValue)
            {
                busca = busca.Where(m => m.Valor >= valorMinimo) as IList<Movimentacao>;
            }

            if (valorMaximo.HasValue)
            {
                busca = busca.Where(m => m.Valor <= valorMaximo) as IList<Movimentacao>;
            }

            if (dataMinima.HasValue)
            {
                busca = busca.Where(m => m.Data >= dataMinima) as IList<Movimentacao>;
            }

            if (dataMaxima.HasValue)
            {
                busca = busca.Where(m => m.Data <= dataMaxima) as IList<Movimentacao>;
            }

            if (tipo.HasValue)
            {
                busca = busca.Where(m => m.Tipo == tipo) as IList<Movimentacao>;
            }

            if (usuarioId.HasValue)
            {
                busca = busca.Where(m => m.UsuarioId == usuarioId) as IList<Movimentacao>;
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
