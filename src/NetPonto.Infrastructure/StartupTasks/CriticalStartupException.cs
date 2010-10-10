using System;
using System.Runtime.Serialization;

namespace NetPonto.Infrastructure.StartupTasks
{
    public class CriticalStartupException : Exception
    {
        public CriticalStartupException()
        {
        }

        public CriticalStartupException(string message) : base(message)
        {
        }

        public CriticalStartupException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CriticalStartupException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}