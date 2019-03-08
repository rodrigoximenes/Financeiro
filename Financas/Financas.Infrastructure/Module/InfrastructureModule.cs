using Financas.Infrastructure.Context;
using Financas.Infrastructure.Repository;
using Ninject.Modules;

namespace Financas.Infrastructure.Module
{
    class InfrastructureModule : NinjectModule
    {
        public override void Load()
        {
            //Contexto
            Bind<FinancasContext>().ToSelf().InTransientScope();

            //Repositorio
            this.Bind<UsuarioRepository>().ToSelf().InSingletonScope();

            //this.Bind(typeof(IBaseRepository<>)).To(typeof(BaseRepository<>));
        }
    }
}
