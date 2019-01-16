using System.Diagnostics;

namespace Tracer
{
    public interface ITracer
    {
        void Trace(TraceEventType traceEventType, string message);

    }
}
