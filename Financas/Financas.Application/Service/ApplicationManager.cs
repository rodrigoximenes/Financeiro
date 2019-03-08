using Financas.Infrastructure.DependencyInjection;

namespace Financas.Application.Service
{
    public class ApplicationManager : IApplicationManager
    {
        public IUsuarioService UsuarioService
        {
            get
            {
                return CompositionRoot.Resolve<IUsuarioService>();
            }
        }
    }
}
