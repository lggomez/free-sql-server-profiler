using System;
using System.Data;

namespace SqlServerTools.Data
{
    public class TraceEventArgs : EventArgs
    {
        public TraceEventArgs()
            : base()
        {
        }

        public TraceEventArgs(DataTable eventsTable)
            : base()
        {
            this.EventsTable = eventsTable;
        }

        public DataTable EventsTable { get; private set; }
    }
}
