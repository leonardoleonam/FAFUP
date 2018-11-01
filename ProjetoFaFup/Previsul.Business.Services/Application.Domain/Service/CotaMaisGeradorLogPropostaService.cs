using Application.Domain.Entidades.CotaMais;
using Application.Domain.Interfaces;
using Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro;
using Application.Domain.Interfaces.Infrastructure.Integrations.PrevisulOnline;
using Application.Domain.Notificacoes;
using Application.Domain.Notificacoes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Application.Domain.Enums;
using Application.Domain.Interfacesl;

namespace Application.Domain.Service
{
    public class CotaMaisGeradorLogPropostaService : ICotaMaisGeradorLogPropostaService
    {
        public ICotaMaisPropostaLogService CotaMaisPropostaLogService { get; }
            
        public INotificacaoService NotificacaoService { get; }       

        public CotaMaisGeradorLogPropostaService(ICotaMaisPropostaLogService cotaMaisPropostaLogService, INotificacaoService notificacaoService)
        {
            CotaMaisPropostaLogService = cotaMaisPropostaLogService;

            NotificacaoService = notificacaoService;
        }

        public RetornoServicoBase GerarLogsProposta(List<CarregarPropostasCotamais> propostaLogs)
        {
            var logsProcessados = new List<LogProcessado>();

            foreach (var log in propostaLogs)
            {                
                log.NumTentativa = (int)(log.NumTentativa == null ? 0 : log.NumTentativa) + 1;

                log.DtUltimoProcessamento = DateTime.Now;

                log.GeradoComSucesso = true;                

                NotificarLogsProcessados(log, logsProcessados);

                CotaMaisPropostaLogService.Atualizar(log);
            }

            if (logsProcessados.Any())
            {
                NotificacaoService.EnviarEmailLogsProcessados(logsProcessados);
            }

            return RetornoServicoBase.SucessoRetorno();
        }

        #region [Metodos Privados]
        private void NotificarLogsProcessados(CarregarPropostasCotamais logProposta, List<LogProcessado> logsPropostas)
        {
            if (logProposta.GeradoComSucesso)
            {
                logProposta.SituacaoProcessamento = StatusGeracaoLog.Sucesso;

                logsPropostas.Add(new LogProcessado
                {
                    Descricao = logProposta.Descricao,                                                           
                    DataUltimoProcessamento = DateTime.Now,
                    Mensagem = "Log gerado com sucesso!"
                });
            }                        
        }              
        #endregion
    }
}
