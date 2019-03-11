using Financas.Domain;
using System;
using System.Collections.Generic;

namespace Financas.Presentation.Models
{
    public class BuscaMovimentacoesModel
    {
        public decimal? ValorMinimo { get; set; }
        public decimal? ValorMaximo { get; set; }
        public DateTime? DataMinima { get; set; }
        public DateTime? DataMaxima { get; set; }
        public TipoMovimentacao Tipo { get; set; }
        public int? UsuarioId { get; set; }
        public IList<Movimentacao> Movimentacoes { get; set; }
        public IList<Usuario> Usuarios { get; set; }

    }
}