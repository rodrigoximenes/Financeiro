using Financas.Application.Service;
using Ninject.Modules;

namespace Financas.Application.Module
{
    public class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            KernelInstance.Bind<ApplicationManager>().ToSelf();

            KernelInstance.Bind<IUsuarioService>().To<UsuarioService>();
        }
    }
}
