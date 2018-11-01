using Previsul.Components.Logging.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Previsul.Components.Logging.Domain.Interfaces
{
    public interface ILogManager
    {
        void LogInfoSync(string message, string requestId, string ipAddress, IDictionary<string, object> messageData, ApplicationEnum application);

        void LogInfoSync(string message, IDictionary<string, object> messageData, ApplicationEnum application);

        void LogInfo(string message, string requestId, string ipAddress, IDictionary<string, object> messageData, ApplicationEnum application);

        void LogInfo(string message, IDictionary<string, object> messageData, ApplicationEnum application);

        void LogWarningSync(string message, IDictionary<string, object> messageData, ApplicationEnum application);

        void LogWarningSync(string message, string requestId, string ipAddress, IDictionary<string, object> messageData, ApplicationEnum application);

        void LogWarning(string message, IDictionary<string, object> messageData, ApplicationEnum application);

        void LogWarning(string message, string requestId, string ipAddress, IDictionary<string, object> messageData, ApplicationEnum application);

        void LogDebugSync(string message, IDictionary<string, object> messageData, ApplicationEnum application);

        void LogDebugSync(string message, string requestId, string ipAddress, IDictionary<string, object> messageData, ApplicationEnum application);

        void LogDebug(string message, IDictionary<string, object> messageData, ApplicationEnum application);

        void LogDebug(string message, string requestId, string ipAddress, IDictionary<string, object> messageData, ApplicationEnum application);

        void LogErrorSync(string message, IDictionary<string, object> messageData, Exception exception, ApplicationEnum application);

        void LogErrorSync(string message, string requestId, string ipAddress, IDictionary<string, object> messageData, Exception exception, ApplicationEnum application);

        void LogError(string message, IDictionary<string, object> messageData, Exception exception, ApplicationEnum application);

        void LogError(string message, string requestId, string ipAddress, IDictionary<string, object> messageData, Exception exception, ApplicationEnum application);

        void LogCriticalSync(string message, IDictionary<string, object> messageData, Exception exception, ApplicationEnum application);

        void LogCriticalSync(string message, string requestId, string ipAddress, IDictionary<string, object> messageData, Exception exception, ApplicationEnum application);
        
        void LogCritical(string message, IDictionary<string, object> messageData, Exception exception, ApplicationEnum application);

        void LogCritical(string message, string requestId, string ipAddress, IDictionary<string, object> messageData, Exception exception, ApplicationEnum application);
    }
}