using Financas.Domain;
using Financas.Domain.Interface;
using Financas.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;

namespace Financas.Infrastructure.Repository
{
    public class UsuarioRepository : IUsuarioRepository

    {
        private readonly FinancasContext context;

        public UsuarioRepository(FinancasContext context)
        {
            this.context = context;
        }

        public void Adicionar(Usuario usuario)
        {
            context.Usuarios.Add(usuario);
            context.SaveChanges();
        }

        public IList<Usuario> Listar()
        {
            return context.Usuarios.ToList();
        }
    }
}
