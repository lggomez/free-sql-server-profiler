using System;

namespace SqlServerTools.Exceptions
{
    public class NotInitializedProfilerException : Exception
    {
        public NotInitializedProfilerException()
            : base("Profiler is not initialized. Initialize profiler first.")
        {
        }
    }
}
