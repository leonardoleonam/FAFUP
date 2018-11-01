using Application.Domain.Interfaces.Infrastructure;
using Previsul.Components.Logging.Domain.Enums;
using Previsul.Components.Logging.Interface;
using System;
using System.Threading.Tasks;

namespace Application.Infrastructure.Services
{
    public class LogHelper : ILogHelper
    {
        public IPrevisulLoggerSync PrevisulLoggerSync { get; }

        public ApplicationEnum Projeto { get; set; }

        public LogHelper(IPrevisulLoggerSync previsulLoggerSync, ApplicationEnum projeto)
        {
            PrevisulLoggerSync = previsulLoggerSync ?? throw new ArgumentNullException(nameof(previsulLoggerSync));
            Projeto = projeto;
        }

        public void LogInfo(string message, Guid? requisicaoId)
        {
            Task.Run(() =>
            {
                PrevisulLoggerSync.LogInfoSync(message, requisicaoId?.ToString(), null, null, Projeto);
            });
        }

        public void LogInfo(LogEventos args)
        {
            Task.Run(() =>
            {
                PrevisulLoggerSync.LogInfoSync(args.Mensagem, args.RequisicaoId?.ToString(), args.EnderecoIp, args.MensagemData, Projeto);
            });
        }

        public void LogWarning(string message, Guid? requisicaoId)
        {
            Task.Run(() =>
            {
                PrevisulLoggerSync.LogWarningSync(message, requisicaoId?.ToString(), null, null, Projeto);
            });
        }

        public void LogWarning(LogEventos args)
        {
            Task.Run(() =>
            {
                PrevisulLoggerSync.LogWarningSync(args.Mensagem, args.RequisicaoId?.ToString(), args.EnderecoIp, args.MensagemData, Projeto);
            });
        }

        public void LogError(string message, Exception ex, Guid? requisicaoId)
        {
            Task.Run(() =>
            {
                PrevisulLoggerSync.LogErrorSync(message, ex, requisicaoId?.ToString(), null, Projeto);
            });
        }

        public void LogError(LogEventos args)
        {
            Task.Run(() =>
            {
                PrevisulLoggerSync.LogErrorSync(args.Mensagem, args.Excecao, args.RequisicaoId?.ToString(), args.EnderecoIp, Projeto);
            });
        }

        public void LogCritical(string message, Exception ex, Guid? requisicaoId)
        {
            Task.Run(() =>
            {
                PrevisulLoggerSync.LogCriticalSync(message, ex, requisicaoId?.ToString(), null, Projeto);
            });
        }

        public void LogCritical(LogEventos args)
        {
            Task.Run(() =>
            {
                PrevisulLoggerSync.LogCriticalSync(args.Mensagem, args.Excecao, args.RequisicaoId?.ToString(), args.EnderecoIp, Projeto);
            });
        }
    }
}
