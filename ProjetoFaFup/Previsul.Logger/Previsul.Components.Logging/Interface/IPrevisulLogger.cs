using System;
using System.Collections.Generic;
using Previsul.Components.Logging.Domain.Enums;

namespace Previsul.Components.Logging.Interface
{
    public interface IPrevisulLogger
    {
        void LogDebug(string message, IDictionary<string, object> messageData, ApplicationEnum application);

        void LogDebug(string message, ApplicationEnum application);

        void LogDebug(string message, string requestId, string ipAddress, ApplicationEnum application);

        void LogDebug(string message, string requestId, string ipAddress, IDictionary<string, object> messageData, ApplicationEnum application);

        void LogInfo(string message, ApplicationEnum application);

        void LogInfo(string message, IDictionary<string, object> messageData, ApplicationEnum application);

        void LogInfo(string message, string requestId, string ipAddress, ApplicationEnum application);

        void LogInfo(string message, string requestId, string ipAddress, IDictionary<string, object> messageData,
            ApplicationEnum application);

        void LogWarning(string message, IDictionary<string, object> messageData, ApplicationEnum application);

        void LogWarning(string message, ApplicationEnum application);

        void LogWarning(string message, string requestId, string ipAddress, ApplicationEnum application);

        void LogWarning(string message, string requestId, string ipAddress, IDictionary<string, object> messageData,
            ApplicationEnum application);

        void LogError(string message, IDictionary<string, object> messageData, Exception exception,
            ApplicationEnum application);

        void LogError(string message, Exception exception, ApplicationEnum application);

        void LogError(string message, Exception exception, string requestId, string ipAddress,
            ApplicationEnum application);

        void LogError(string message, Exception exception, string requestId, string ipAddress,
            IDictionary<string, object> messageData, ApplicationEnum application);

        void LogCritical(string message, IDictionary<string, object> messageData, Exception exception,
            ApplicationEnum application);

        void LogCritical(string message, Exception exception, ApplicationEnum application);

        void LogCritical(string message, Exception exception, string requestId, string ipAddress,
            ApplicationEnum application);

        void LogCritical(string message, Exception exception, string requestId, string ipAddress,
            IDictionary<string, object> messageData, ApplicationEnum application);
    }
}
