using Financas.Application.Module;
using Financas.Infrastructure.DependencyInjection;
using Financas.Infrastructure.Module;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebMatrix.WebData;

namespace Financas.Presentation
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            WebSecurity.InitializeDatabaseConnection("FinancasContext", "Usuarios", "Id", "Nome", true);

            CompositionRoot.Init();
            CompositionRoot.AddModule(new InfrastructureModule());
            CompositionRoot.AddModule(new ApplicationModule());
        }
    }
}
