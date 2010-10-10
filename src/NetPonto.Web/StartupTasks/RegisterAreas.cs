using System.Web.Mvc;
using NetPonto.Infrastructure;
using NetPonto.Infrastructure.StartupTasks;

namespace NetPonto.Web.StartupTasks
{
    public class RegisterAreas : IStartupTask
    {
        public void Execute()
        {
            AreaRegistration.RegisterAllAreas();
        }
    }
}