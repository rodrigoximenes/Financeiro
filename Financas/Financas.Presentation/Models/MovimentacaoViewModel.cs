using Financas.Domain;
using System;

namespace Financas.Presentation.Models
{
    public class MovimentacaoViewModel
    {
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public TipoMovimentacao Tipo { get; set; }
        public Usuario Usuario { get; set; }
    }
}