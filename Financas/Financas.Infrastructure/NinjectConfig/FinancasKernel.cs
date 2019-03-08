using Financas.Infrastructure.Module;
using Ninject;

namespace Financas.Infrastructure.NinjectConfig
{
    public static class FinancasKernel
    {
        private readonly static IKernel _kernel = new StandardKernel(new InfrastructureModule());

        public static TEntity GetInstance<TEntity>()
        {
            return _kernel.Get<TEntity>();
        }
    }
}
