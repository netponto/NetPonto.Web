using System;
using System.Collections.Generic;

namespace NetPonto.Infrastructure.StartupTasks
{
    public class StartupTaskRunner : IStartupTaskRunner
    {
        private readonly IEnumerable<IStartupTask> _tasks;
        private readonly ILogErrors _logErrors;

        public StartupTaskRunner(IEnumerable<IStartupTask> tasks, ILogErrors logErrors)
        {
            _tasks = tasks;
            _logErrors = logErrors;
        }

        public void ExecuteAllTasks()
        {
            foreach (var startupTask in _tasks)
            {
                try
                {
                    startupTask.Execute();
                }
                catch (Exception e)
                {
                    _logErrors.Log(string.Format("Error executing task {0}", startupTask), e);
                }
            }
        }
    }
}