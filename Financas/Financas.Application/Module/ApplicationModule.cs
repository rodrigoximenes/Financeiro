using Financas.Application.Service;
using Ninject.Modules;

namespace Financas.Application.Module
{
    public class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            KernelInstance.Bind<IApplicationManager>().To<ApplicationManager>();
            KernelInstance.Bind<IUsuarioService>().To<UsuarioService>();
            KernelInstance.Bind<IMovimentacaoService>().To<MovimentacaoService>();
        }
    }
}
