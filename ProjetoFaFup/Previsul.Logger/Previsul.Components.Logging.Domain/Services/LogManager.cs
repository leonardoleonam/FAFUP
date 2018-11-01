using Previsul.Components.Logging.Domain.Enums;
using Previsul.Components.Logging.Domain.Helpers;
using Previsul.Components.Logging.Domain.Interfaces;
using Previsul.Components.Logging.Domain.Model;
using Previsul.Components.Logging.Domain.Services.Handler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Previsul.Components.Logging.Domain.Services
{
    public class LogManager : ILogManager
    {
        public ILogRepository LogRepository { get; }

        public LogManager(ILogRepository logRepository)
        {
            LogRepository = logRepository ?? throw new ArgumentNullException(nameof(logRepository));
        }

        public void LogInfoSync(string message, string requestId, string ipAddress,
            IDictionary<string, object> messageData,
            ApplicationEnum application)
        {
            LogSync(SeverityEnum.Information, message, requestId, ipAddress, messageData, GetCallingSourceMethod(), application);
        }

        public void LogInfoSync(string message, IDictionary<string, object> messageData, ApplicationEnum application)
        {
            LogSync(SeverityEnum.Information, message, null, null, messageData, GetCallingSourceMethod(), application);
        }

        public void LogInfo(string message, string requestId, string ipAddress, IDictionary<string, object> messageData,
            ApplicationEnum application)
        {
            Log(SeverityEnum.Information, message, requestId, ipAddress, messageData, GetCallingSourceMethod(),
                application);
        }

        public void LogInfo(string message, IDictionary<string, object> messageData, ApplicationEnum application)
        {
            Log(SeverityEnum.Information, message, null, null, messageData, GetCallingSourceMethod(), application);
        }

        public void LogWarningSync(string message, IDictionary<string, object> messageData, ApplicationEnum application)
        {
            LogSync(SeverityEnum.Warning, message, null, null, messageData, GetCallingSourceMethod(), application);
        }

        public void LogWarningSync(string message, string requestId, string ipAddress,
            IDictionary<string, object> messageData,
            ApplicationEnum application)
        {
            LogSync(SeverityEnum.Warning, message, requestId, ipAddress, messageData, GetCallingSourceMethod(),
                application);
        }

        public void LogWarning(string message, IDictionary<string, object> messageData, ApplicationEnum application)
        {
            Log(SeverityEnum.Warning, message, null, null, messageData, GetCallingSourceMethod(), application);
        }

        public void LogWarning(string message, string requestId, string ipAddress,
            IDictionary<string, object> messageData,
            ApplicationEnum application)
        {
            Log(SeverityEnum.Warning, message, requestId, ipAddress, messageData, GetCallingSourceMethod(),
                application);
        }

        public void LogDebugSync(string message, IDictionary<string, object> messageData, ApplicationEnum application)
        {
            LogSync(SeverityEnum.Verbose, message, null, null, messageData, GetCallingSourceMethod(), application);
        }

        public void LogDebugSync(string message, string requestId, string ipAddress,
            IDictionary<string, object> messageData,
            ApplicationEnum application)
        {
            LogSync(SeverityEnum.Verbose, message, requestId, ipAddress, messageData, GetCallingSourceMethod(),
                application);
        }

        public void LogDebug(string message, IDictionary<string, object> messageData, ApplicationEnum application)
        {
            LogSync(SeverityEnum.Verbose, message, null, null, messageData, GetCallingSourceMethod(), application);
        }

        public void LogDebug(string message, string requestId, string ipAddress,
            IDictionary<string, object> messageData, ApplicationEnum application)
        {
            Log(SeverityEnum.Verbose, message, requestId, ipAddress, messageData, GetCallingSourceMethod(),
                application);
        }

        public void LogErrorSync(string message, IDictionary<string, object> messageData, Exception exception,
            ApplicationEnum application)
        {
            LogWithExceptionSync(SeverityEnum.Error, message, null, null, messageData, exception,
                GetCallingSourceMethod(), application);
        }

        public void LogErrorSync(string message, string requestId, string ipAddress,
            IDictionary<string, object> messageData, Exception exception,
            ApplicationEnum application)
        {
            LogWithExceptionSync(SeverityEnum.Error, message, requestId, ipAddress, messageData, exception,
                GetCallingSourceMethod(), application);
        }

        public void LogError(string message, IDictionary<string, object> messageData, Exception exception,
            ApplicationEnum application)
        {
            LogWithException(SeverityEnum.Error, message, null, null, messageData, exception, GetCallingSourceMethod(),
                application);
        }

        public void LogError(string message, string requestId, string ipAddress,
            IDictionary<string, object> messageData, Exception exception,
            ApplicationEnum application)
        {
            LogWithException(SeverityEnum.Error, message, requestId, ipAddress, messageData, exception,
                GetCallingSourceMethod(), application);
        }

        public void LogCriticalSync(string message, string requestId, string ipAddress,
            IDictionary<string, object> messageData, Exception exception,
            ApplicationEnum application)
        {
            LogWithExceptionSync(SeverityEnum.Critical, message, requestId, ipAddress, messageData, exception,
                GetCallingSourceMethod(), application);
        }

        public void LogCriticalSync(string message, IDictionary<string, object> messageData, Exception exception,
            ApplicationEnum application)
        {
            LogWithExceptionSync(SeverityEnum.Critical, message, null, null, messageData, exception,
                GetCallingSourceMethod(), application);
        }

        public void LogCritical(string message, IDictionary<string, object> messageData, Exception exception,
            ApplicationEnum application)
        {
            LogWithException(SeverityEnum.Critical, message, null, null, messageData, exception,
                GetCallingSourceMethod(), application);
        }

        public void LogCritical(string message, string requestId, string ipAddress,
            IDictionary<string, object> messageData, Exception exception,
            ApplicationEnum application)
        {
            LogWithException(SeverityEnum.Critical, message, requestId, ipAddress, messageData, exception,
                GetCallingSourceMethod(), application);
        }

        #region [Private Methods]

        private static LogEntry LogEntryFactory(SeverityEnum severity, string message, string requestId,
            string ipAddress,
            ICollection<KeyValuePair<string, object>> extendProperties, string source, ApplicationEnum application)
        {
            var str = FormatMessageData(extendProperties);

            var logData = new LogEntry
            {
                Severity = (TraceEventType)Enum.Parse(typeof(TraceEventType), severity.ToString()),
                Message = $"{message}{str}",
                RequestId = requestId == null ? (Guid?)null : new Guid(requestId),
                IpAddress = ipAddress,
                Source = source,
                TimeStamp = DateTime.Now,
                Application = application,
                MachineName = Environment.MachineName
            };

            return logData;
        }

        private void Log(SeverityEnum severity, string message, string requestId, string ipAddress,
            ICollection<KeyValuePair<string, object>> extendProperties, string source, ApplicationEnum application)
        {
            var logData = LogEntryFactory(severity, message, requestId, ipAddress, extendProperties, source, application);

            CommandExecutorHandler.Execute(() =>
            {
                if (BroadCastForSlackChannel(severity))
                    SlackClient.SendMessage(PayloadFactory.CreateMessagePayLoad(logData));

                return LogRepository.Insert(logData);
            });
        }

        private void LogSync(SeverityEnum severity, string message, string requestId, string ipAddress,
            ICollection<KeyValuePair<string, object>> extendProperties, string source, ApplicationEnum application)
        {
            var logData = LogEntryFactory(severity, message, requestId, ipAddress, extendProperties, source, application);

            CommandExecutorHandler.Execute(() =>
            {
                if (BroadCastForSlackChannel(severity))
                    SlackClient.SendMessage(PayloadFactory.CreateMessagePayLoad(logData));

                return LogRepository.Insert(logData);
            });
        }

        private void LogWithExceptionSync(SeverityEnum severity, string message, string requestId, string ipAddress,
            IDictionary<string, object> messageData, Exception exception, string source, ApplicationEnum application)
        {
            var dictionaryErrors = GetExceptionMessage(exception);

            LogSync(severity, $"{message}{FormatMessageData(messageData)}", requestId, ipAddress, dictionaryErrors,
                source, application);
        }

        private void LogWithException(SeverityEnum severity, string message, string requestId, string ipAddress,
            IDictionary<string, object> messageData, Exception exception, string source, ApplicationEnum application)
        {
            var dictionaryErrors = GetExceptionMessage(exception);

            Log(severity, $"{message}{FormatMessageData(messageData)}", requestId, ipAddress, dictionaryErrors, source, application);
        }

        private static Dictionary<string, object> GetExceptionMessage(Exception exception)
        {
            var dictionary = new Dictionary<string, object>();

            if (exception != null)
            {
                dictionary.Add("Exception", exception.Message);
                dictionary.Add("Source", exception.Source);

                if (exception.InnerException != null)
                {
                    var innerException = exception.InnerException;

                    while (innerException.InnerException != null)
                        innerException = innerException.InnerException;

                    dictionary.Add("MostInnerException", innerException.Message);
                }

                dictionary.Add("StackTrace", exception.StackTrace);
            }

            return dictionary;
        }

        private static string FormatMessageData(ICollection<KeyValuePair<string, object>> messageData)
        {
            if (messageData == null || messageData.Count == 0) return string.Empty;

            var messageBuilder = new StringBuilder();

            foreach (var keyValuePair in messageData)
                messageBuilder.AppendFormat(" | {0}: {1}", keyValuePair.Key, keyValuePair.Value);

            return messageBuilder.ToString();
        }

        private static string GetCallingSourceMethod()
        {
            var method = new StackFrame(3).GetMethod();

            if ((method.DeclaringType != null) == false) return string.Empty;

            return $"{method.DeclaringType.FullName as object}.{method.Name as object}";
        }

        private static bool BroadCastForSlackChannel(SeverityEnum severity)
        {
            return severity == SeverityEnum.Critical || severity == SeverityEnum.Error;
        }

        #endregion
    }
}
