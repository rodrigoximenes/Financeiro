using Financas.Domain.Interface;

namespace Financas.Application.Service
{
    public interface IApplicationManager
    {
        IUsuarioRepository UsuarioRepository { get; }
    }
}
