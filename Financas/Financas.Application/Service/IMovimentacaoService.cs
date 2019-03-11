using Financas.Domain;
using System.Collections.Generic;
using System;

namespace Financas.Application.Service
{
    public interface IMovimentacaoService
    {
        void Adicionar(Movimentacao movimentacao);
        ICollection<Movimentacao> ListarTodas();
        IList<Movimentacao> BuscarPorUsuario(int usuarioId);
        IList<Movimentacao> Buscar(decimal? valorMinimo, decimal? valorMaximo, DateTime? dataMinima, DateTime? dataMaxima, TipoMovimentacao? tipo, int? usuarioId);
    }
}
