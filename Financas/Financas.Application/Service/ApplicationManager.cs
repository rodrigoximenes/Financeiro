using System;
using Financas.Infrastructure.DependencyInjection;

namespace Financas.Application.Service
{
    public class ApplicationManager : IApplicationManager
    {
        public IMovimentacaoService MovimentacaoService
        {
            get
            {
                return CompositionRoot.Resolve<IMovimentacaoService>();
            }
        }

        public IUsuarioService UsuarioService
        {
            get
            {
                return CompositionRoot.Resolve<IUsuarioService>();
            }
        }
    }
}
