using System;
using System.Diagnostics;

namespace Tracer
{
    public class TracerFile
    {
        public TracerFile(string logPath = "myTracerLog.log")
        {
            Trace.Listeners.Add(new TextWriterTraceListener(logPath));
            Trace.AutoFlush = true;
        }

        public void Tracer(TraceEventType traceEventType, object obj)
        {
            //Trace.TraceInformation(msg);
            Trace.WriteLine(DateTime.Now + "\t" + traceEventType + "\t\t" + obj);
        }
    }
}
