using Application.Domain;
using Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro;
using Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro.Contratos;
using Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro.Contratos.Enums;
using Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro.Handler;
using Application.Domain.Util;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace Application.Integration.I4Pro.Services
{
    public class GeradorDocumentosApoliceService : IGeradorDocumentosApoliceService
    {
        public II4ProServiceHandler I4ProServiceHandler { get; }
        
        public const int I4ProCodigoSucesso = 0;

        public const int CondfiguracaoApolice = 16;

        public GeradorDocumentosApoliceService(II4ProServiceHandler i4ProServiceHandler)
        {
            I4ProServiceHandler = i4ProServiceHandler ?? throw new ArgumentNullException(nameof(i4ProServiceHandler));
        }

        public RetornoServico<I4ProGeradorDocumentosApoliceRetorno> GerarDocumentosApolice(string codigoApolice, string base64, string nomeDocumento)
        {
            var arquivoJson = JsonConvert.SerializeObject(new I4ProGeradorDocumentosApoliceRequisicao
            {
                Anexar = new I4ProDocumento
                {
                    CodigoApolice = codigoApolice,
                    IdentificadorTipo = (int)TipoDocumentoEnum.Pdf,
                    IdentificadorDominio = CondfiguracaoApolice,
                    ImagemArquivo = nomeDocumento,
                    ImagemTipoCoonteudo = "application/pdf",
                    Imagem = base64
                }
            });

            try
            {
                var parametrosRequest = new RestRequest("Emissao/EmitirApolice", Method.POST)
                {
                    JsonSerializer = new RestSharpJsonSerializer()
                };
                
                parametrosRequest.AddJsonBody(new I4ProEmissaoApoliceRequisicao
                {
                    Acao = "anexardocumento",
                    ArquivoJson = arquivoJson,
                    CodigoRetorno = "string",
                    DescricaoRetorno = "string"
                });

                parametrosRequest.AddHeader("Content-Type", "application/json; charset=utf-8");

                var gerarArquivoApoliceServiceResult = I4ProServiceHandler.Enviar(parametrosRequest);

                var resposta = JsonConvert.DeserializeObject<I4ProGeradorDocumentosApoliceRetorno>(gerarArquivoApoliceServiceResult.Content);

                return resposta.CodigoRetorno == I4ProCodigoSucesso ? RetornoServico<I4ProGeradorDocumentosApoliceRetorno>.SucessoRetorno(resposta) : RetornoServico<I4ProGeradorDocumentosApoliceRetorno>.RetornoErro(ErroEnum.ErroIntegracao, resposta.Retorno);
            }
            catch (I4ProException ex)
            {
                return RetornoServico<I4ProGeradorDocumentosApoliceRetorno>.RetornoErro(ErroEnum.ErroIntegracao, ex.Message);
            }
            catch (Exception ex)
            {
                return RetornoServico<I4ProGeradorDocumentosApoliceRetorno>.RetornoErro(ErroEnum.Excecao, ex.Message);
            }
        }
    }
}
