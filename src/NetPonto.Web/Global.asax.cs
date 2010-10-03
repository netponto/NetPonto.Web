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
            TryAndSetupNhProf();

            ConfigureAutofac();

            ConfigureSpark();

            UpdateDatabaseSchema();

            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }

        private void TryAndSetupNhProf()
        {
            NhProf.Initialize();
        }

        private void ConfigureAutofac()
        {
            var builder = new ContainerBuilder();
            var currentAssembly = typeof(MvcApplication).Assembly;

            builder.RegisterModule(new InfrastructureModule(currentAssembly, ConfigurationManager.ConnectionStrings["ApplicationServices"]
                                                                                 .ConnectionString));

            _containerProvider = new ContainerProvider(builder.Build());
            ControllerBuilder.Current.SetControllerFactory(new AutofacControllerFactory(ContainerProvider));
        }

        private void ConfigureSpark()
        {
            var settings = new SparkSettings()
                .SetDebug(true)
                .AddAssembly(typeof (MvcApplication).Assembly)
                .AddNamespace("System")
                .AddNamespace("System.Collections.Generic")
                .AddNamespace("System.Linq")
                .AddNamespace("System.Web.Mvc")
                .AddNamespace("System.Web.Mvc.Html")
                .AddNamespace("NetPonto.Web.Extensions");

            ViewEngines.Engines.Add(new SparkViewFactory(settings));
        }

        private void UpdateDatabaseSchema()
        {
            _containerProvider.ApplicationContainer.Resolve<SchemaUpdate>().Execute(true, true);
        }
    }
}