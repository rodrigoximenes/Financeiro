using System;
using Financas.Domain.Interface;
using Financas.Infrastructure.DependencyInjection;
using Financas.Infrastructure.Repository;

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
