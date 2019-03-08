using System;
using System.Collections.Generic;
using Financas.Domain;
using Financas.Domain.Interface;
using Financas.Infrastructure.DependencyInjection;

namespace Financas.Application.Service
{
    public class MovimentacaoService : IMovimentacaoService
    {
        private readonly IMovimentacaoRepository _movimentacaoRepository = CompositionRoot.Resolve<IMovimentacaoRepository>();

        public void Adicionar(Movimentacao movimentacao)
        {
            _movimentacaoRepository.Add(movimentacao);
        }

        public ICollection<Movimentacao> ListarTodas()
        {
            return _movimentacaoRepository.FindAll();
        }
    }
}
