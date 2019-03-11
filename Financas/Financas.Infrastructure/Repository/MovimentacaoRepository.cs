using System.Collections.Generic;
using Financas.Domain;
using Financas.Domain.Interface;
using Financas.Infrastructure.Context;
using System.Linq;

namespace Financas.Infrastructure.Repository
{
    public class MovimentacaoRepository : BaseRepository<Movimentacao>, IMovimentacaoRepository
    {
        private readonly FinancasContext context;

        public MovimentacaoRepository(FinancasContext context) : base(context)
        {
            this.context = context;
        }

        public IList<Movimentacao> FindAllById(int id)
        {
            return context.Movimentacoes.Where(m => m.UsuarioId == id).ToList();
        }
    }
}
