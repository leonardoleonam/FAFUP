using System;
using System.Collections.Generic;
using Previsul.Components.Logging.Domain.Enums;

namespace Previsul.Components.Logging.Interface
{
    public interface IPrevisulLoggerSync
    {
        void LogDebugSync(string message, IDictionary<string, object> messageData, ApplicationEnum application);

        void LogDebugSync(string message, ApplicationEnum application);

        void LogDebugSync(string message, string requestId, string ipAddress, ApplicationEnum application);

        void LogDebugSync(string message, string requestId, string ipAddress, IDictionary<string, object> messageData, ApplicationEnum application);

        void LogInfoSync(string message, ApplicationEnum application);

        void LogInfoSync(string message, IDictionary<string, object> messageData, ApplicationEnum application);

        void LogInfoSync(string message, string requestId, string ipAddress, ApplicationEnum application);

        void LogInfoSync(string message, string requestId, string ipAddress, IDictionary<string, object> messageData, ApplicationEnum application);

        void LogWarningSync(string message, IDictionary<string, object> messageData, ApplicationEnum application);

        void LogWarningSync(string message, ApplicationEnum application);

        void LogWarningSync(string message, string requestId, string ipAddress, ApplicationEnum application);

        void LogWarningSync(string message, string requestId, string ipAddress, IDictionary<string, object> messageData, ApplicationEnum application);

        void LogErrorSync(string message, IDictionary<string, object> messageData, Exception exception, ApplicationEnum application);

        void LogErrorSync(string message, Exception exception, ApplicationEnum application);

        void LogErrorSync(string message, Exception exception, string requestId, string ipAddress, ApplicationEnum application);

        void LogErrorSync(string message, Exception exception, string requestId, string ipAddress, IDictionary<string, object> messageData, ApplicationEnum application);

        void LogCriticalSync(string message, IDictionary<string, object> messageData, Exception exception, ApplicationEnum application);

        void LogCriticalSync(string message, Exception exception, ApplicationEnum application);

        void LogCriticalSync(string message, Exception exception, string requestId, string ipAddress, ApplicationEnum application);

        void LogCriticalSync(string message, Exception exception, string requestId, string ipAddress, IDictionary<string, object> messageData, ApplicationEnum application);
    }
}