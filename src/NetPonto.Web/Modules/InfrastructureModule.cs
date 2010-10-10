using System.Configuration;
using System.Reflection;
using Autofac;
using Autofac.Integration.Web;
using Autofac.Integration.Web.Mvc;
using NetPonto.Infrastructure;
using NetPonto.Services.Events;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Module = Autofac.Module;

namespace NetPonto.Web.Modules
{
    public class InfrastructureModule : Module
    {
        private readonly Assembly _assemblyWithControllers;
        private readonly Assembly _assemblyWithInfrastructure;
        private readonly string _connectionString;

        public InfrastructureModule(Assembly assemblyWithControllers, Assembly assemblyWithInfrastructure,  string connectionString)
        {
            _assemblyWithControllers = assemblyWithControllers;
            _assemblyWithInfrastructure = assemblyWithInfrastructure;
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterControllers(_assemblyWithControllers);

            builder.RegisterAssemblyTypes(_assemblyWithInfrastructure).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(_assemblyWithInfrastructure).AsSelf();

            builder.RegisterType<ConfigureNHibernate>()
                .WithParameters(new[]
                                    {
                                        new NamedParameter("connectionString",
                                                           _connectionString),
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

            
        }
    }
}