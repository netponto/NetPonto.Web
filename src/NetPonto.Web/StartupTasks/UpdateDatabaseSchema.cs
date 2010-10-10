using System;
using NetPonto.Infrastructure;
using NetPonto.Infrastructure.StartupTasks;
using NHibernate.Tool.hbm2ddl;

namespace NetPonto.Web.StartupTasks
{
    public class UpdateDatabaseSchema : IStartupTask
    {
        private readonly SchemaUpdate _schemaUpdate;

        public UpdateDatabaseSchema(SchemaUpdate schemaUpdate)
        {
            _schemaUpdate = schemaUpdate;
        }

        public void Execute()
        {
            _schemaUpdate.Execute(true, true);
        }
    }
}