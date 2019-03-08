using Financas.Domain.Interface;

namespace Financas.Application.Service
{
    public interface IApplicationManager
    {
        IUsuarioService UsuarioService { get; }


    }
}
