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

namespace Application.Domain.Service
{
    public class CotaMaisGeradorArquivosApoliceService : ICotaMaisGeradorArquivosApoliceService
    {
        public ICotaMaisPropostaArquivoService CotaMaisPropostaArquivoService { get; }

        public IGeradorDocumentosApoliceService I4ProGeradorDocumentosApoliceService { get; }

        public INotificacaoService NotificacaoService { get; }

        public IPrevisulOnlineService PrevisulOnlineService { get; }


        public CotaMaisGeradorArquivosApoliceService(
            ICotaMaisPropostaArquivoService cotaMaisPropostaArquivoService,
            IGeradorDocumentosApoliceService i4ProGeradorDocumentosApoliceService,
            INotificacaoService notificacaoService,
            IPrevisulOnlineService previsulOnlineService)
        {
            CotaMaisPropostaArquivoService = cotaMaisPropostaArquivoService ?? throw new ArgumentNullException(nameof(cotaMaisPropostaArquivoService));
            I4ProGeradorDocumentosApoliceService = i4ProGeradorDocumentosApoliceService ?? throw new ArgumentNullException(nameof(i4ProGeradorDocumentosApoliceService));
            NotificacaoService = notificacaoService ?? throw new ArgumentNullException(nameof(notificacaoService));
            PrevisulOnlineService = previsulOnlineService ?? throw new ArgumentNullException(nameof(previsulOnlineService));
        }

        public RetornoServicoBase GerarArquivosApolice(List<PropostaArquivo> propostaArquivos)
        {
            var arquivosProcessados = new List<ArquivoProcessado>();

            foreach (var arquivo in propostaArquivos)
            {
                var arrayProtocolo = arquivo.Proposta.Protocolo.Split('/');
                var protocolo = Convert.ToInt32(arrayProtocolo[0]);
                var ano = Convert.ToInt32(arrayProtocolo[1]);

                arquivo.NumeroTentativa = (int)(arquivo.NumeroTentativa == null ? 0 : arquivo.NumeroTentativa) + 1;

                arquivo.DataUltimoProcessamento = DateTime.Now;

                GerarDocumentoPropostaApolice(protocolo, ano, arquivo);

                GerarDocumentoCondicaoComercialApolice(protocolo, ano, arquivo);

                NotificarArquivosProcessados(arquivo, arquivosProcessados);

                CotaMaisPropostaArquivoService.Atualizar(arquivo);
            }

            if (arquivosProcessados.Any())
            {
                NotificacaoService.EnviarEmailArquivosProcessados(arquivosProcessados);
            }

            return RetornoServicoBase.SucessoRetorno();
        }

        #region [Metodos Privados]

        private void NotificarArquivosProcessados(PropostaArquivo arquivo, List<ArquivoProcessado> arquivosProcessados)
        {
            if (arquivo.GeradoComSucesso)
            {
                arquivo.SituacaoProcessamento = StatusPropostaArquivoEnum.Sucesso;

                arquivosProcessados.Add(new ArquivoProcessado
                {
                    NumApolice = arquivo.Proposta.Apolice,
                    NumProposta = arquivo.Proposta.Protocolo,
                    StatusProcessamentoArquivo = arquivo.SituacaoProcessamento,
                    Chave = arquivo.CodigoProcessamento,
                    DtEmissao = DateTime.Now,
                    Mensagem = "Arquivos carregados no I4PRO"
                });
            }

            if (arquivo.GeradoComInconsistencia)
            {
                arquivo.SituacaoProcessamento = StatusPropostaArquivoEnum.LoteArquivoInconsistente;

                arquivosProcessados.Add(new ArquivoProcessado
                {
                    NumApolice = arquivo.Proposta.Apolice,
                    NumProposta = arquivo.Proposta.Protocolo,
                    Chave = arquivo.CodigoProcessamento,
                    StatusProcessamentoArquivo = arquivo.SituacaoProcessamento,
                    DtEmissao = DateTime.Now,
                    Mensagem = arquivo.SituacaoUploadProposta ? "Erro ao efetuar upload de arquivo Proposta" : "Erro ao efetuar upload de arquivo Condicao"
                });
            }

            if (arquivo.GeradoComErro)
            {
                arquivo.SituacaoProcessamento = StatusPropostaArquivoEnum.Erro;

                arquivosProcessados.Add(new ArquivoProcessado
                {
                    NumApolice = arquivo.Proposta.Apolice,
                    NumProposta = arquivo.Proposta.Protocolo,
                    Chave = arquivo.CodigoProcessamento,
                    StatusProcessamentoArquivo = arquivo.SituacaoProcessamento,
                    DtEmissao = null,
                    Mensagem = "Erro ao efetuar upload dos arquivos: (Proposta) e (Condicao) "
                });
            }
        }

        private void GerarDocumentoPropostaApolice(int protocolo, int ano, PropostaArquivo arquivo)
        {
            if (!arquivo.SituacaoUploadProposta)
            {
                var base64DocumentoRetorno = PrevisulOnlineService.Gerar(TipoDocumentoEnum.Proposta.ToDescriptionString(), protocolo, ano);

                if (base64DocumentoRetorno.Sucesso && !string.IsNullOrEmpty(base64DocumentoRetorno.ObjetoRetorno.Proposta))
                {
                    var arquivoCotacaoI4Pro = I4ProGeradorDocumentosApoliceService.GerarDocumentosApolice(arquivo.Proposta.Apolice, base64DocumentoRetorno.ObjetoRetorno.Proposta, $"PROPOSTA {arquivo.Proposta.Protocolo}.pdf");

                    arquivo.SituacaoUploadProposta = arquivoCotacaoI4Pro.Sucesso;
                 
                }
            }
        }

        private void GerarDocumentoCondicaoComercialApolice(int protocolo, int ano, PropostaArquivo arquivo)
        {
            if (!arquivo.SituacaoUploadCondicao)
            {
                var base64CondicaoDocumentoRetorno = PrevisulOnlineService.Gerar(TipoDocumentoEnum.Condicao.ToDescriptionString(), protocolo, ano);

                if (base64CondicaoDocumentoRetorno.Sucesso && !string.IsNullOrEmpty(base64CondicaoDocumentoRetorno.ObjetoRetorno.Condicao))
                {
                    var arquivoCotacaoI4Pro = I4ProGeradorDocumentosApoliceService.GerarDocumentosApolice(arquivo.Proposta.Apolice, base64CondicaoDocumentoRetorno.ObjetoRetorno.Condicao, $"CONDICAO {arquivo.Proposta.Protocolo}.pdf");

                    arquivo.SituacaoUploadCondicao = arquivoCotacaoI4Pro.Sucesso;
                }
            }
        }

        #endregion
    }
}
