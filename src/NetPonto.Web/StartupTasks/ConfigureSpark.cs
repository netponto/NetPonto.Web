using System;
using System.Web.Mvc;
using NetPonto.Infrastructure;
using NetPonto.Infrastructure.StartupTasks;
using Spark;
using Spark.Web.Mvc;

namespace NetPonto.Web.StartupTasks
{
    public class ConfigureSpark : IStartupTask
    {
        public void Execute()
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
    }
}