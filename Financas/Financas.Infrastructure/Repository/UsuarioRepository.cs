using Financas.Domain;
using Financas.Domain.Interface;
using Financas.Infrastructure.Context;

namespace Financas.Infrastructure.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(FinancasContext context) : base(context)
        {
        }
    }
}
