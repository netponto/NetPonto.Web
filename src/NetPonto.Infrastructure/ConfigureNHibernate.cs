using System;
using System.Collections.Generic;
using System.Reflection;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;

namespace NetPonto.Infrastructure
{
    public class ConfigureNHibernate
    {
        private readonly string _connectionString;
        private readonly IEnumerable<Assembly> _assembliesWithEntities;

        public ConfigureNHibernate(string connectionString, IEnumerable<Assembly> assembliesWithEntities)
        {
            _connectionString = connectionString;
            _assembliesWithEntities = assembliesWithEntities;
            
        }

        public Configuration CreateConfiguration()
        {
            FluentConfiguration configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                              .ConnectionString(c => c.Is(_connectionString))
                              .AdoNetBatchSize(50))
                .Mappings(m => m.AutoMappings.Add(AutoMap.Assemblies(new AutoMappingConfiguration(),
                                                                     _assembliesWithEntities)))
                .ExposeConfiguration(cfg => cfg.SetProperty("generate_statistics", "true"));
            return configuration.BuildConfiguration();   
        }

        class AutoMappingConfiguration : DefaultAutomappingConfiguration
        {
            public override bool ShouldMap(Type type)
            {
                return typeof (IEntity).IsAssignableFrom(type);
            }
        }
    }

}