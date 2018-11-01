using Application.Domain.Entidades.CotaMais;
using Application.Domain.Enums;
using Application.Domain.Interfaces;
using Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro;
using Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro.Contratos;
using Application.Domain.Notificacoes;
using Application.Domain.Notificacoes.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Domain.Service
{
    public class CotaMaisEmissaoApoliceService : ICotaMaisEmissaoApoliceService
    {
        public ICotaMaisPropostaService CotaMaisPropostaService { get; }

        public IEmissaoApoliceService I4ProEmitirApoliceService { get; }

        public INotificacaoService NotificacaoService { get; }

        public CotaMaisEmissaoApoliceService(
            ICotaMaisPropostaService cotaMaisPropostaService,
            IEmissaoApoliceService i4ProEmitirApoliceService,
            INotificacaoService notificacaoService)
        {
            CotaMaisPropostaService = cotaMaisPropostaService ?? throw new ArgumentNullException(nameof(cotaMaisPropostaService));
            I4ProEmitirApoliceService = i4ProEmitirApoliceService ?? throw new ArgumentNullException(nameof(i4ProEmitirApoliceService));
            NotificacaoService = notificacaoService ?? throw new ArgumentNullException(nameof(notificacaoService));
        }

        public RetornoServicoBase EmitirApolice(List<Proposta> propostas)
        {
            var propostasProcessadas = new List<PropostaProcessada>();

            foreach (var proposta in propostas)
            {
                var gerarPropostaRetorno = CotaMaisPropostaService.GerarProposta(proposta.Id);

                proposta.SitProcessamento = StatusPropostaEnum.NaoDefinido;

                if (gerarPropostaRetorno.Sucesso)
                {
                    if (proposta.NumTentativa.HasValue)
                    {
                        proposta.NumTentativa++;
                    }
                    else
                    {
                        proposta.NumTentativa = 1;
                    }

                    var emissaoResultado = I4ProEmitirApoliceService.EmitirApolice(gerarPropostaRetorno.ObjetoRetorno);

                    if (emissaoResultado.Sucesso)
                    {
                        proposta.SitProcessamento = StatusPropostaEnum.Sucesso;
                        proposta.Apolice = emissaoResultado.ObjetoRetorno.Apolice.CodigoApolice;
                        proposta.Contrato = emissaoResultado.ObjetoRetorno.Apolice.NumeroContrato;
                        proposta.DtEmissao = emissaoResultado.ObjetoRetorno.Apolice.DataEmissao;

                        AdicionarPropostasProcessadasComSucesso(propostasProcessadas, proposta);
                    }
                    else
                    {
                        proposta.SitProcessamento = StatusPropostaEnum.Erro;
                        AdicionarPropostasProcessadasComErro(propostasProcessadas, proposta, emissaoResultado);
                    }

                    proposta.PropostaJson.Add(new PropostaJson
                    {
                        DtCriacao = DateTime.Now,
                        JsonRequest = gerarPropostaRetorno.ObjetoRetorno,
                        JsonResponse = emissaoResultado.Sucesso ? emissaoResultado.ObjetoRetorno.Retorno : emissaoResultado.ErrosSerialized,
                        CodProcessamento = proposta.CodProcessamento,
                        SitProcessamento = (int)proposta.SitProcessamento
                    });
                }

                CotaMaisPropostaService.Atualizar(proposta);
            }

            if (propostasProcessadas.Any())
            {
                NotificacaoService.EnviarEmailPropostasProcessadas(propostasProcessadas);
            }

            return RetornoServicoBase.SucessoRetorno();
        }

        #region [Metodos privados]

        private void AdicionarPropostasProcessadasComSucesso(List<PropostaProcessada> propostasProcessadas, Proposta proposta)
        {
            bool valorInferior = false;
            if (proposta.Produto.CodProduto == 4)
                if(proposta.PropostaGarantias.Sum(x => x.ValorGrupo) <= 50)
                    valorInferior = true;

            propostasProcessadas.Add(new PropostaProcessada
            {
                NumApolice = proposta.Apolice,
                NumProposta = proposta.Protocolo,
                NumContrato = proposta.Contrato,
                DtEmissao = proposta.DtEmissao,
                Chave = proposta.CodProcessamento,
                StatusProposta = proposta.SitProcessamento,
                Mensagem = !valorInferior ? "Proposta emitida no I4PRO": "Proposta emitida no I4PRO. <font style=\"background-color:yellow\"><b><u>Prêmio total das coberturas é abaixo do limite mínimo de R$ 50,00 reais. A somatória dos prêmios das coberturas, deverá ser igual a R$ 50,00 reais. Ajustar manualmente no I4PRO.</u></b></font>"
            });
        }

        private void AdicionarPropostasProcessadasComErro(
            List<PropostaProcessada> propostasProcessadas,
            Proposta proposta,
            RetornoServico<I4ProEmissaoApoliceRetorno> emissaoResultado)
        {
            propostasProcessadas.Add(new PropostaProcessada
            {
                NumApolice = string.Empty,
                NumProposta = proposta.Protocolo,
                NumContrato = string.Empty,
                DtEmissao = null,
                Chave = proposta.CodProcessamento,
                StatusProposta = proposta.SitProcessamento,
                Mensagem = emissaoResultado.ErrosSerialized
            });
        }

        #endregion
    }
}
