using Financas.Domain;
using Financas.Infrastructure.Context;
using System.Collections.Generic;

namespace Financas.Infrastructure.Repository
{
    public class UsuarioRepository
    {
        private readonly FinancasContext context;

        public UsuarioRepository(FinancasContext context)
        {
            this.context = context;
        }

        public void Adicionar(Usuario usario)
        {

        }

        public IList<Usuario> Listar()
        {
            return null;
        }
    }
}
