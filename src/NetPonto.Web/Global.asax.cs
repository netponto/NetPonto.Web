using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Web;
using Autofac.Integration.Web.Mvc;
using NetPonto.Infrastructure;
using NetPonto.Services.Events;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Module = Autofac.Module;

namespace NetPonto.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication, IContainerProviderAccessor
    {
        static IContainerProvider _containerProvider;

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

            UpdateDatabase();

            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }

        private void TryAndSetupNhProf()
        {
            NhProf.Initialize();
        }

        private void UpdateDatabase()
        {
            _containerProvider.ApplicationContainer.Resolve<SchemaUpdate>().Execute(true, true);
        }

        private void ConfigureAutofac()
        {
            var builder = new ContainerBuilder();
            var currentAssembly = typeof(MvcApplication).Assembly;

            builder.RegisterModule(new InfrastructureModule(currentAssembly));

            _containerProvider = new ContainerProvider(builder.Build());

            ControllerBuilder.Current.SetControllerFactory(new AutofacControllerFactory(ContainerProvider));
        }
        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }

        public class InfrastructureModule : Module
        {
            private readonly Assembly _currentAssembly;

            public InfrastructureModule(Assembly currentAssembly)
            {
                _currentAssembly = currentAssembly;
            }

            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<ConfigureNHibernate>()
                .WithParameters(new[]
                                    {
                                        new NamedParameter("connectionString",
                                                           ConfigurationManager
                                                               .ConnectionStrings["ApplicationServices"]
                                                               .ConnectionString),
                                        new NamedParameter("assembliesWithEntities",
                                                           new[] {typeof (Event).Assembly})
                                    })
                .SingleInstance();

                builder.RegisterAdapter<ConfigureNHibernate, NHibernate.Cfg.Configuration>(configure => configure.CreateConfiguration())
                    .SingleInstance();

                builder.RegisterAdapter<NHibernate.Cfg.Configuration, ISessionFactory>(configuration => configuration.BuildSessionFactory())
                    .SingleInstance();

                builder.RegisterType<SchemaUpdate>();

                // TODO: create transaction when opening, abort on error, commit on success
                builder.RegisterAdapter<ISessionFactory, ISession>(factory => factory.OpenSession())
                    .HttpRequestScoped();

                builder.RegisterGeneric(typeof(NHibernateRepository<>))
                    .As(typeof(IRepository<>))
                    .HttpRequestScoped();

                builder.RegisterControllers(_currentAssembly);
                builder.RegisterAssemblyTypes(_currentAssembly);
            }
        }
    }
}