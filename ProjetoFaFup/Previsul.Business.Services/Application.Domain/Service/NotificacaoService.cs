using Application.Domain.Entidades;
using Application.Domain.Interfaces;
using Application.Domain.Interfaces.Infrastructure;
using Application.Domain.Notificacoes;
using Application.Domain.Notificacoes.EmailTemplate;
using Application.Domain.Notificacoes.Model;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace Application.Domain.Service
{
    public class NotificacaoService : INotificacaoService
    {
        public IConfiguracaoPbsService ConfiguracaoPbsService { get; }

        public IEmailService EmailService { get; }

        public NotificacaoService(IEmailService emailService, IConfiguracaoPbsService configuracaoPbsService)
        {
            EmailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            ConfiguracaoPbsService = configuracaoPbsService ?? throw new ArgumentNullException(nameof(configuracaoPbsService));
        }
        
        public void EnviarEmailPropostasProcessadas(List<PropostaProcessada> propostasProcessadas)
        {
            var template = new PropostaProcessadaEmailTemplate
            {
                PropostasProcessadas = propostasProcessadas
            };
            
            using (var emailMessage = new MailMessage())
            {
                emailMessage.IsBodyHtml = true;

                var emailTo = ConfiguracaoPbsService.Buscar(ConfiguracaoPbsChaves.EmailEquipeTo).Split(';');
                
                foreach (var to in emailTo)
                    emailMessage.To.Add(new MailAddress(to));
                
                emailMessage.From = new MailAddress(ConfiguracaoPbsService.Buscar(ConfiguracaoPbsChaves.EmailFrom));
                emailMessage.Subject = "INTEGRACAO PROPOSTAS COTA+ I4PRO";
                emailMessage.Body = template.TransformText();

                EmailService.EnviarEmail(emailMessage);
            }
        }

        public void EnviarEmailArquivosProcessados(List<ArquivoProcessado> arquivosProcessados)
        {
            var template = new ArquivoProcessadoEmailTemplate
            {
                ArquivosProcessados = arquivosProcessados
            };

            using (var emailMessage = new MailMessage())
            {
                emailMessage.IsBodyHtml = true;

                var emailTo = ConfiguracaoPbsService.Buscar(ConfiguracaoPbsChaves.EmailEquipeTo).Split(';');

                foreach (var to in emailTo)
                    emailMessage.To.Add(new MailAddress(to));

                emailMessage.From = new MailAddress(ConfiguracaoPbsService.Buscar(ConfiguracaoPbsChaves.EmailFrom));
                emailMessage.Subject = "INTEGRACAO ARQUIVOS PROPOSTAS COTA+ I4PRO";
                emailMessage.Body = template.TransformText();

                EmailService.EnviarEmail(emailMessage);
            }
        }

        public void EnviarEmailLogsProcessados(List<LogProcessado> logsProcessados)
        {
            var template = new LogProcessadoEmailTemplate
            {
                LogsProcessados = logsProcessados
            };

            using (var emailMessage = new MailMessage())
            {
                emailMessage.IsBodyHtml = true;

                var emailTo = ConfiguracaoPbsService.Buscar(ConfiguracaoPbsChaves.EmailEquipeTo).Split(';');

                foreach (var to in emailTo)
                    emailMessage.To.Add(new MailAddress(to));

                emailMessage.From = new MailAddress(ConfiguracaoPbsService.Buscar(ConfiguracaoPbsChaves.EmailFrom));
                emailMessage.Subject = "PROCESSADO LOG PROPOSTA COTA+";
                emailMessage.Body = template.TransformText();

                EmailService.EnviarEmail(emailMessage);
            }
        }
    }
}
