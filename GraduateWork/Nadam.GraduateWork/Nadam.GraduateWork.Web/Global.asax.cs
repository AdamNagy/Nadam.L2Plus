using Autofac;
using Autofac.Integration.WebApi;
using Nadam.GraduateWork.CoreContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Nadam.GraduateWork.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var core = Assembly.LoadFile(@"G:\GitRepositories\Nadam.L2Plus\GraduateWork\Nadam.GraduateWork\Nadam.GraduateWork.Web\bin\Nadam.GraduateWork.Core.dll");

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyTypes(core)
                   //.Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces();
            var container = builder.Build();

            // var globalConfiguration = GlobalConfiguration.Configuration;
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            
            using (var scope = container.BeginLifetimeScope())
            {
                var service = scope.Resolve<INotesService>();
            }
        }
    }
}
