using Financas.Domain;
using System.Collections.Generic;

namespace Financas.Application.Service
{
    public interface IUsuarioService 
    {
        void Adicionar(Usuario usuario);

        ICollection<Usuario> ListarTodos();

        Usuario BuscarPorId(int id);
    }
}
