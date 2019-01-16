using System;
using System.ComponentModel.Composition;
using System.Diagnostics;

namespace Tracer.DataBaseTracer
{
    [Export(typeof(ITracer))]
    public class DatabaseTracer : ITracer
    {
        private LogDbContext context;

        [ImportingConstructor]
        public DatabaseTracer()
        {
            context = new LogDbContext();
        }

        public void Trace(TraceEventType traceEventType, string message)
        {
            LogEntry logEntry = new LogEntry()
            {
                Time = DateTime.Now,
                LogType = traceEventType.ToString(),
                Message = message
            };

            context.LogEntries.Add(logEntry);

            context.SaveChanges();
        }
    }
}
