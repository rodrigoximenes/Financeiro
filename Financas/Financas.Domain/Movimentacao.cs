using System;

namespace Financas.Domain
{
    public class Movimentacao
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public TipoMovimentacao Tipo { get; set; }
        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
