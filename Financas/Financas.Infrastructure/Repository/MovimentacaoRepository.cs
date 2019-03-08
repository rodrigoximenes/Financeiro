using Financas.Domain;
using Financas.Domain.Interface;
using Financas.Infrastructure.Context;

namespace Financas.Infrastructure.Repository
{
    public class MovimentacaoRepository : BaseRepository<Movimentacao>, IMovimentacaoRepository
    {
        public MovimentacaoRepository(FinancasContext context) : base(context)
        {
        }
    }
}
