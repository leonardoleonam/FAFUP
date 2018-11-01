using Newtonsoft.Json;
using Previsul.Components.Logging.Domain.Model;
using System;
using System.Diagnostics;

namespace Previsul.Components.Logging.Domain.Helpers
{
    public static class PayloadFactory
    {
        public static MessagePayload CreateMessagePayLoad(LogEntry log)
        {
            return new MessagePayload
            {
                Application = log.Application.ToString(),
                Attachments = new[]
                {
                    new Attachment
                    {
                        Title = log.Application.ToString(),
                        Text = JsonConvert.SerializeObject(log.Message),
                        Color = GetColorStyle(log.Severity),
                        Fallback = log.Severity.ToString()
                    }
                }
            };
        }
        
        private static string GetColorStyle(TraceEventType severity)
        {
            switch (severity)
            {
                case TraceEventType.Information:
                    return "#007bff";

                case TraceEventType.Warning:
                    return "#ffc107";

                case TraceEventType.Verbose:
                    return "#6c757d";

                case TraceEventType.Critical:
                case TraceEventType.Error:
                    return "#dc3545";

                default: return "#F00";
            }
        }
    }
}
