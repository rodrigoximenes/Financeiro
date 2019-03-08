using Financas.Domain;
using System;

namespace Financas.Presentation.Models
{
    public class MovimentacaoModel
    {
        public decimal Valor { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Data { get; set; }
        public TipoMovimentacao Tipo { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}