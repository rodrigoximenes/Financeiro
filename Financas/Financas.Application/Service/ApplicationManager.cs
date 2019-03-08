using Financas.Domain.Interface;
using Financas.Infrastructure.DependencyInjection;
using Financas.Infrastructure.Repository;

namespace Financas.Application.Service
{
    public class ApplicationManager : IApplicationManager
    {
        public IUsuarioRepository UsuarioRepository
        {
            get { return CompositionRoot.Resolve<UsuarioRepository>(); }
        }
    }
}
