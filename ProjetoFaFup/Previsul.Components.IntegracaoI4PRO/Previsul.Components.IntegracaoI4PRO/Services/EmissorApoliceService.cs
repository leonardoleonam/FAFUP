using Application.Domain;
using Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro;
using Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro.Contratos;
using Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro.Handler;
using Application.Domain.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using System;

namespace Application.Integration.I4Pro.Services
{
    public class EmissorApoliceService : IEmissorApoliceService
    {
        public II4ProServiceHandler I4ProServiceHandler { get; }
        
        public const int I4ProCodigoSucesso = 0;

        public EmissorApoliceService(IRestClient restClient,
            II4ProServiceHandler i4ProServiceHandler)
        {
            I4ProServiceHandler = i4ProServiceHandler ?? throw new ArgumentNullException(nameof(i4ProServiceHandler));
        }

        public RetornoServico<I4ProEmissaoApoliceRetorno> EmitirApolice(string apoliceJson)
        {
            var parametrosRequest = new RestRequest("Emissao/EmitirApolice", Method.POST)
            {
                JsonSerializer = new RestSharpJsonSerializer()
            };

            parametrosRequest.AddHeader("Content-Type", "application/json; charset=utf-8");
            parametrosRequest.AddJsonBody(new I4ProEmissaoApoliceRequisicao { ArquivoJson = apoliceJson, CodigoRetorno = "string", DescricaoRetorno = "string" });

            try
            {
                var emissaoApoliceServiceResult = I4ProServiceHandler.Enviar(parametrosRequest);

                var resposta = JsonConvert.DeserializeObject<I4ProEmissaoApoliceRetorno>(emissaoApoliceServiceResult.Content);

                if (resposta.CodigoRetorno == I4ProCodigoSucesso)
                {
                    resposta.Apolice = JsonConvert.DeserializeObject<I4ProApolice>(resposta.Retorno,
                        new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy HH:mm:ss" });

                    return RetornoServico<I4ProEmissaoApoliceRetorno>.SucessoRetorno(resposta);
                }

                return RetornoServico<I4ProEmissaoApoliceRetorno>.RetornoErro(ErroEnum.ErroIntegracao, resposta.Retorno);

            }
            catch (I4ProException ex)
            {
                return RetornoServico<I4ProEmissaoApoliceRetorno>.RetornoErro(ErroEnum.ErroIntegracao, ex.Message);
            }
            catch (Exception ex)
            {
                return RetornoServico<I4ProEmissaoApoliceRetorno>.RetornoErro(ErroEnum.Excecao, ex.Message);
            }
        }
    }
}
