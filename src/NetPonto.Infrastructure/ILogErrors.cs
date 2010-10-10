using System;

namespace NetPonto.Infrastructure
{
    public interface ILogErrors
    {
        void Log(string message, Exception exception);
    }
}