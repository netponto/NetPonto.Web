using System;
using NetPonto.Infrastructure;
using NetPonto.Infrastructure.StartupTasks;

namespace NetPonto.Web.StartupTasks
{
    public class TryAndWireNhProf : IStartupTask
    {
        public void Execute()
        {
            NhProf.Initialize();
        }
    }
}