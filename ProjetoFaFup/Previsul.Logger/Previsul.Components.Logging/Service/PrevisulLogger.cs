using Previsul.Components.Logging.Domain.Enums;
using Previsul.Components.Logging.Domain.Interfaces;
using Previsul.Components.Logging.Domain.Services;
using Previsul.Components.Logging.Interface;
using Previsul.Components.LoggingRepository;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Previsul.Components.Logging.Service
{
    public class PrevisulLogger : IPrevisulLogger
    {
        public ILogManager LogManager { get; }

        public PrevisulLogger(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString)) throw new ArgumentException("ConnectionString not found");

            LogManager = new LogManager(new SqlLogRepository(connectionString));
        }

        public void LogDebug(string message, IDictionary<string, object> messageData, ApplicationEnum application)
        {
            ExecuteAction(() => { LogManager.LogDebug(message, messageData, application); });
        }

        public void LogDebug(string message, ApplicationEnum application)
        {
            ExecuteAction(() => { LogManager.LogDebug(message, null, application); });
        }

        public void LogDebug(string message, string requestId, string ipAddress, ApplicationEnum application)
        {
            ExecuteAction(() => { LogManager.LogDebug(message, requestId, ipAddress, null, application); });
        }

        public void LogDebug(string message, string requestId, string ipAddress, IDictionary<string, object> messageData, ApplicationEnum application)
        {
            ExecuteAction(() => { LogManager.LogDebug(message, requestId, ipAddress, messageData, application); });
        }

        public void LogInfo(string message, ApplicationEnum application)
        {
            ExecuteAction(() => { LogManager.LogInfo(message, null, application); });
        }

        public void LogInfo(string message, IDictionary<string, object> messageData, ApplicationEnum application)
        {
            ExecuteAction(() => { LogManager.LogInfo(message, messageData, application); });
        }

        public void LogInfo(string message, string requestId, string ipAddress, ApplicationEnum application)
        {
            ExecuteAction(() => { LogManager.LogInfo(message, requestId, ipAddress, null, application); });
        }

        public void LogInfo(string message, string requestId, string ipAddress, IDictionary<string, object> messageData, ApplicationEnum application)
        {
            ExecuteAction(() => { LogManager.LogInfo(message, requestId, ipAddress, messageData, application); });
        }

        public void LogWarning(string message, IDictionary<string, object> messageData, ApplicationEnum application)
        {
            ExecuteAction(() => { LogManager.LogWarning(message, messageData, application); });
        }

        public void LogWarning(string message, ApplicationEnum application)
        {
            ExecuteAction(() => { LogManager.LogWarning(message, null, application); });
        }

        public void LogWarning(string message, string requestId, string ipAddress, ApplicationEnum application)
        {
            ExecuteAction(() => { LogManager.LogWarning(message, requestId, ipAddress, null, application); });
        }

        public void LogWarning(string message, string requestId, string ipAddress, IDictionary<string, object> messageData, ApplicationEnum application)
        {
            ExecuteAction(() => { LogManager.LogWarning(message, requestId, ipAddress, messageData, application); });
        }

        public void LogError(string message, IDictionary<string, object> messageData, Exception exception, ApplicationEnum application)
        {
            ExecuteAction(() => { LogManager.LogError(message, messageData, exception, application); });
        }

        public void LogError(string message, Exception exception, ApplicationEnum application)
        {
            ExecuteAction(() => { LogManager.LogError(message, null, exception, application); });
        }

        public void LogError(string message, Exception exception, string requestId, string ipAddress, ApplicationEnum application)
        {
            ExecuteAction(() => { LogManager.LogError(message, requestId, ipAddress, null, exception, application); });
        }

        public void LogError(string message, Exception exception, string requestId, string ipAddress, IDictionary<string, object> messageData, ApplicationEnum application)
        {
            ExecuteAction(() => { LogManager.LogError(message, requestId, ipAddress, messageData, exception, application); });
        }

        public void LogCritical(string message, IDictionary<string, object> messageData, Exception exception, ApplicationEnum application)
        {
            ExecuteAction(() => { LogManager.LogCritical(message, messageData, exception, application); });
        }

        public void LogCritical(string message, Exception exception, ApplicationEnum application)
        {
            ExecuteAction(() => { LogManager.LogCritical(message, null, exception, application); });
        }

        public void LogCritical(string message, Exception exception, string requestId, string ipAddress, ApplicationEnum application)
        {
            ExecuteAction(() => { LogManager.LogCritical(message, requestId, ipAddress, null, exception, application); });
        }

        public void LogCritical(string message, Exception exception, string requestId, string ipAddress, IDictionary<string, object> messageData, ApplicationEnum application)
        {
            ExecuteAction(() => { LogManager.LogCritical(message, requestId, ipAddress, null, exception, application); });
        }

        #region [Private Methods]

        private static void ExecuteAction(Action function)
        {
            try
            {
                function();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
            }
        }

        #endregion
    }
}
