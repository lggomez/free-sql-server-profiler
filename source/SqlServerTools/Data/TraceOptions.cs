using System;

namespace SqlServerTools.Data
{
    [Flags]
    public enum TraceOptions
    {
        ProduceRowSet   = 1,
        FileRollover    = 2,
        ShutdownOnError = 4,
        ProduceBlackBox = 8
    }
}
