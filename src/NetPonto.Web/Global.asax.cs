using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Web;
using Autofac.Integration.Web.Mvc;
using NetPonto.Infrastructure;
using NetPonto.Infrastructure.StartupTasks;
using NetPonto.Web.Helpers;
using NetPonto.Web.Modules;
using NHibernate.Tool.hbm2ddl;
using Spark;
using Spark.Web.Mvc;

namespace NetPonto.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication, IContainerProviderAccessor
    {
        static IContainerProvider _containerProvider;
        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }


        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            ConfigureAutofac();

            RunStartupTasks();

            RegisterRoutes(RouteTable.Routes);
        }

        private void ConfigureAutofac()
        {
            var builder = new ContainerBuilder();
            var currentAssembly = typeof(MvcApplication).Assembly;
            var infrastructureAssembly = typeof (IRepository<>).Assembly;

            var connectionString = ConfigurationManager
                .ConnectionStrings["ApplicationServices"]
                .ConnectionString;
            
            builder.RegisterModule(new InfrastructureModule(infrastructureAssembly, connectionString));
            builder.RegisterModule(new WebModule(currentAssembly));
            builder.RegisterModule(new StartupTasksModule());

            builder.RegisterInstance(this).As<HttpApplication>();
            builder.RegisterType<LogErrorsToAppData>().As<ILogErrors>();

            _containerProvider = new ContainerProvider(builder.Build());
            ControllerBuilder.Current.SetControllerFactory(new AutofacControllerFactory(ContainerProvider));
        }

        private void RunStartupTasks()
        {
            _containerProvider.ApplicationContainer.Resolve<IStartupTaskRunner>().ExecuteAllTasks();
        }
    }
}