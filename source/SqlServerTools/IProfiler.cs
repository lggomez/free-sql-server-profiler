using AnfiniL.SqlServerTools.Data;
using SqlServerTools.Data;
using System;

namespace SqlServerTools
{
    public interface IProfiler : IDisposable
    {
        int TraceId {get;}
        TraceStatus Status {get;}
        
        CreateTraceErrorCode Initialize(TraceOptions traceOptions, string traceFilePath, int maxFileSize);
        CreateTraceErrorCode Initialize(TraceOptions traceOptions, string traceFilePath, DateTime? stopTime);
        CreateTraceErrorCode Initialize(TraceOptions traceOptions, string traceFile, int? maxFileSize, DateTime? stopTime);
        CreateTraceErrorCode Initialize(TraceOptions traceOptions, string traceFilePath);
        

        AddTraceEventErrorCode AddTraceEvent(TraceEvent traceEvent, params TraceField[] traceFields);
        AddTraceFilterErrorCode AddTraceFilter<T>(TraceField traceField, LogicalOperator logicalOp, ComparisonOperator compOp, T value);

        StatusErrorCode Start();
        StatusErrorCode Stop();
        StatusErrorCode Close();

        event EventHandler<TraceEventArgs> TraceEvent;
        
        IProfiler Copy();
    }
}
