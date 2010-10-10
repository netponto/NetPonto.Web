using System;
using System.IO;
using System.Web;
using NetPonto.Infrastructure;

namespace NetPonto.Web.Helpers
{
    public class LogErrorsToAppData : ILogErrors
    {
        private readonly HttpApplication _application;
        private readonly string _errorsPath;

        private static object _fileLock = new object();

        public LogErrorsToAppData(HttpApplication application)
        {
            _application = application;
            _errorsPath = _application.Server.MapPath("~/App_Data/errors.txt");
        }

        public void Log(string message, Exception exception)
        {
            lock (_fileLock)
            {
                using (var output= new StreamWriter(_errorsPath))
                {
                    var now = DateTime.Now;
                    output.WriteLine("{0} - {1} : {2}", now, message, exception);
                }
            }
        }
    }
}