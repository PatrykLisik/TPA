using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.ComponentModel.Composition;

namespace Tracer
{
    [Export(typeof(ITracer))]
    public class FileTracer : ITracer
    {
        public FileTracer()
        {
            Init("myTracerLog.log");
        }
        public FileTracer(string logPath = "myTracerLog.log")
        {
            Init(logPath);
        }

        private static void Init(string logPath)
        {
            if (File.Exists(logPath))
            {
                File.Delete(logPath);
            }

            System.Diagnostics.Trace.Listeners.Add(new TextWriterTraceListener(logPath));
            System.Diagnostics.Trace.AutoFlush = true;
        }

        public void Trace(TraceEventType traceEventType, string message)
        {
            System.Diagnostics.Trace.WriteLine(DateTime.Now + "\t" + traceEventType + "\t\t" + message);
        }
    }
}
