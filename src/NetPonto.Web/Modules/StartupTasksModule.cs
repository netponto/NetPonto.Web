using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using NetPonto.Web.StartupTasks;

namespace NetPonto.Web.Modules
{
    public class StartupTasksModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(this.GetType().Assembly)
                .InNamespaceOf<UpdateDatabaseSchema>()
                .AsImplementedInterfaces();
        }
    }
}