using Previsul.Components.Logging.Domain.Enums;
using Previsul.Components.Logging.Domain.Interfaces;
using Previsul.Components.Logging.Domain.Services;
using Previsul.Components.LoggingRepository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Previsul.Components.Logging.Interface;

namespace Previsul.Components.Logging.Service
{
    public class PrevisulLoggerSync : IPrevisulLoggerSync
    {
        public ILogManager LogManager { get; }

        public PrevisulLoggerSync(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString)) throw new ArgumentException("ConnectionString not found");

            LogManager = new LogManager(new SqlLogRepository(connectionString));
        }

        public void LogDebugSync(string message, IDictionary<string, object> messageData, ApplicationEnum application)
        {
            ExecuteActionAsync(() => { LogManager.LogDebugSync(message, messageData, application); });
        }

        public void LogDebugSync(string message, ApplicationEnum application)
        {
            LogManager.LogDebugSync(message, null, application);
        }

        public void LogDebugSync(string message, string requestId, string ipAddress, ApplicationEnum application)
        {
            ExecuteActionAsync(() => { LogManager.LogDebugSync(message, requestId, ipAddress, null, application); });
        }

        public void LogDebugSync(string message, string requestId, string ipAddress, IDictionary<string, object> messageData, ApplicationEnum application)
        {
            ExecuteActionAsync(() => { LogManager.LogDebugSync(message, requestId, ipAddress, messageData, application); });
        }

        public void LogInfoSync(string message, ApplicationEnum application)
        {
            ExecuteActionAsync(() => { LogManager.LogInfoSync(message, null, application); });
        }

        public void LogInfoSync(string message, IDictionary<string, object> messageData, ApplicationEnum application)
        {
            ExecuteActionAsync(() => { LogManager.LogInfoSync(message, messageData, application); });
        }

        public void LogInfoSync(string message, string requestId, string ipAddress, ApplicationEnum application)
        {
            ExecuteActionAsync(() => { LogManager.LogInfoSync(message, requestId, ipAddress, null, application); });
        }

        public void LogInfoSync(string message, string requestId, string ipAddress, IDictionary<string, object> messageData, ApplicationEnum application)
        {
            ExecuteActionAsync(() => { LogManager.LogInfoSync(message, requestId, ipAddress, messageData, application); });
        }

        public void LogWarningSync(string message, IDictionary<string, object> messageData, ApplicationEnum application)
        {
            ExecuteActionAsync(() => { LogManager.LogWarningSync(message, messageData, application); });
        }

        public void LogWarningSync(string message, ApplicationEnum application)
        {
            ExecuteActionAsync(() => { LogManager.LogWarningSync(message, null, application); });
        }

        public void LogWarningSync(string message, string requestId, string ipAddress, ApplicationEnum application)
        {
            ExecuteActionAsync(() => { LogManager.LogWarningSync(message, requestId, ipAddress, null, application); });
        }

        public void LogWarningSync(string message, string requestId, string ipAddress, IDictionary<string, object> messageData, ApplicationEnum application)
        {
            ExecuteActionAsync(() => { LogManager.LogWarningSync(message, requestId, ipAddress, messageData, application); });
        }

        public void LogErrorSync(string message, IDictionary<string, object> messageData, Exception exception, ApplicationEnum application)
        {
            ExecuteActionAsync(() => { LogManager.LogErrorSync(message, messageData, exception, application); });
        }

        public void LogErrorSync(string message, Exception exception, ApplicationEnum application)
        {
            ExecuteActionAsync(() => { LogManager.LogErrorSync(message, null, exception, application); });
        }

        public void LogErrorSync(string message, Exception exception, string requestId, string ipAddress, ApplicationEnum application)
        {
            ExecuteActionAsync(() => { LogManager.LogErrorSync(message, requestId, ipAddress, null, exception, application); });
        }

        public void LogErrorSync(string message, Exception exception, string requestId, string ipAddress, IDictionary<string, object> messageData, ApplicationEnum application)
        {
            ExecuteActionAsync(() => { LogManager.LogErrorSync(message, requestId, ipAddress, messageData, exception, application); });
        }

        public void LogCriticalSync(string message, IDictionary<string, object> messageData, Exception exception, ApplicationEnum application)
        {
            ExecuteActionAsync(() => { LogManager.LogCriticalSync(message, messageData, exception, application); });
        }

        public void LogCriticalSync(string message, Exception exception, ApplicationEnum application)
        {
            ExecuteActionAsync(() => { LogManager.LogCriticalSync(message, null, exception, application); });
        }

        public void LogCriticalSync(string message, Exception exception, string requestId, string ipAddress, ApplicationEnum application)
        {
            ExecuteActionAsync(() => { LogManager.LogCriticalSync(message, requestId, ipAddress, null, exception, application); });
        }

        public void LogCriticalSync(string message, Exception exception, string requestId, string ipAddress, IDictionary<string, object> messageData, ApplicationEnum application)
        {
            ExecuteActionAsync(() => { LogManager.LogCriticalSync(message, requestId, ipAddress, null, exception, application); });
        }

        #region [Private Methods]

        private void ExecuteActionAsync(Action function)
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