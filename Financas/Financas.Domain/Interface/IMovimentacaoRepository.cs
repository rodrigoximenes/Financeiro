using System.Collections.Generic;

namespace Financas.Domain.Interface
{
    public interface IMovimentacaoRepository : IBaseRepository<Movimentacao>
    {
        IList<Movimentacao> FindAllById(int id);
    }
}
