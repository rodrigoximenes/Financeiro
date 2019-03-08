using Ninject;
using Ninject.Modules;
using Ninject.Parameters;
using System.Collections.Generic;
using System.Linq;

namespace Financas.Infrastructure.DependencyInjection
{
    public class CompositionRoot
    {
        private static IKernel _ninjectKernel;

        public static T Resolve<T>(string bindingName)
        {
            return _ninjectKernel.Get<T>(bindingName);
        }

        public static T Resolve<T>()
        {
            return _ninjectKernel.Get<T>();
        }

        public static T Resolve<T>(params IParameter[] parameters)
        {
            return _ninjectKernel.Get<T>(parameters);
        }

        public static T Resolve<T>(string bindingName, IParameter[] parameters)
        {
            return _ninjectKernel.Get<T>(bindingName, parameters);
        }

        public static void Init()
        {
            if (_ninjectKernel == null)
                _ninjectKernel = new StandardKernel(new NinjectSettings {LoadExtensions = false});
        }

        public static void AddModule(NinjectModule module)
        {
            var exists = _ninjectKernel.GetModules().FirstOrDefault(x => x.Name == module.Name);
            if (exists == null)
                _ninjectKernel.Load(module);
        }

        public static void Wire(IEnumerable<INinjectModule> modules)
        {
            _ninjectKernel = modules.First().Kernel;
        }

        public static void Wire<T>(IEnumerable<INinjectModule> modules)
            where T : INinjectModule
        {
            foreach (var module in modules)
            {
                if (module is T)
                {
                    _ninjectKernel = module.Kernel;
                    break;
                }
            }
        }
    }
}
