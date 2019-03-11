using Financas.Domain;
using System.Collections.Generic;
using System;

namespace Financas.Application.Service
{
    public interface IMovimentacaoService
    {
        void Adicionar(Movimentacao movimentacao);
        IEnumerable<Movimentacao> ListarTodas();
        IEnumerable<Movimentacao> BuscarPorUsuario(int usuarioId);
        IEnumerable<Movimentacao> Buscar(decimal? valorMinimo, decimal? valorMaximo, DateTime? dataMinima, DateTime? dataMaxima, TipoMovimentacao? tipo, int? usuarioId);
    }
}
