using System;
using System.Collections.Generic;

namespace Application.Domain.Interfaces.Infrastructure
{
    public interface ILogHelper
    {
        void LogInfo(string message, Guid? requisicaoId);

        void LogInfo(LogEventos args);

        void LogWarning(string message, Guid? requisicaoId);

        void LogWarning(LogEventos args);

        void LogError(string message, Exception ex, Guid? requisicaoId);

        void LogError(LogEventos args);

        void LogCritical(string message, Exception ex, Guid? requisicaoId);

        void LogCritical(LogEventos args);
    }

    public class LogEventos
    {
        public Guid? RequisicaoId { get; set; }

        public string EnderecoIp { get; set; }

        public string Mensagem { get; set; }

        public Exception Excecao { get; set; }

        public IDictionary<string, object> MensagemData { get; set; }
    }
}
