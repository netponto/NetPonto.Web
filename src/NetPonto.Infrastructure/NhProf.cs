using System;
using System.Reflection;

namespace NetPonto.Infrastructure
{
    public static class NhProf
    {
        public static string LastStatus;
        public static void Initialize()
        {
            try
            {
                var prof = Assembly.Load("HibernatingRhinos.Profiler.Appender, Version=1.0.0.0, Culture=neutral, PublicKeyToken=0774796e73ebf640")
                    .GetType("HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler", true, true);
                prof.GetMethod("Initialize", BindingFlags.Static | BindingFlags.Public, null, new Type[] { }, null)
                    .Invoke(null, new object[] { });
                LastStatus = "Initialized";
            }
            catch (System.IO.FileNotFoundException)
            {
                LastStatus = "File Not Found";
                // If we can't find the file, fine, don't do anything
            }
        }

        public static void FlushAllMessages()
        {
            try
            {
                var prof = Assembly.Load("HibernatingRhinos.Profiler.Appender, Version=1.0.0.0, Culture=neutral, PublicKeyToken=0774796e73ebf640")
                    .GetType("HibernatingRhinos.Profiler.Appender.ProfilerInfrastructure", true, true);
                prof.GetMethod("FlushAllMessages", BindingFlags.Static | BindingFlags.Public, null, new Type[] { }, null)
                    .Invoke(null, new object[] { });
                LastStatus = "Flushed all messages";
            }
            catch (System.IO.FileNotFoundException)
            {
                // If we can't find the file, fine, don't do anything
                LastStatus = "File Not Found";
            }
        }
    }
}