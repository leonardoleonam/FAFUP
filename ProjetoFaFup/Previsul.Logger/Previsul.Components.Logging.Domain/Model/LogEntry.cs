using Previsul.Components.Logging.Domain.Enums;
using System;
using System.Diagnostics;

namespace Previsul.Components.Logging.Domain.Model
{
    public class LogEntry
    {
        public int Id { get; set; }

        public DateTime TimeStamp { get; set; }

        public string MachineName { get; set; }
        
        public string Source { get; set; }

        public string Message { get; set; }
        
        public Guid? RequestId { get; set; }

        public string IpAddress { get; set; }
        
        public TraceEventType Severity { get; set; }

        public ApplicationEnum Application { get; set; }
    }
}
