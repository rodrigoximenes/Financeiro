using Financas.Domain.Interface;
using Financas.Infrastructure.Context;
using Financas.Infrastructure.Repository;
using Ninject.Modules;

namespace Financas.Infrastructure.Module
{
    public class InfrastructureModule : NinjectModule
    {
        public override void Load()
        {
            //Contexto
            Bind<FinancasContext>().ToSelf().InTransientScope();

            //Repositorio
            this.Bind<IUsuarioRepository>().To<UsuarioRepository>();
            this.Bind(typeof(IBaseRepository<>)).To(typeof(BaseRepository<>));
        }
    }
}
