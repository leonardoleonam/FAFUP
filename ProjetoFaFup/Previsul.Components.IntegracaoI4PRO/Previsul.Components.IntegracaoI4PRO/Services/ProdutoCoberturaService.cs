using Application.Domain;
using Application.Domain.Entidades;
using Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro.Handler;
using Application.Domain.Util;
using Application.Integration.I4Pro;
using Application.Integration.I4Pro.Services.Handler;
using Newtonsoft.Json;
using Previsul.Components.IntegracaoI4PRO.Interfaces;
using Previsul.Components.IntegracaoI4PRO.Objetos_Requisicao;
using Previsul.Components.IntegracaoI4PRO.Objetos_Retorno;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Previsul.Components.IntegracaoI4PRO.Services
{
    public class ProdutoCoberturaService : IProdutoCoberturaService
    {
        public IRestClient RestClient { get; }

        public II4ProServiceHandler I4ProServiceHandler { get; }

        public const int I4ProCodigoSucesso = 0;

        public ProdutoCoberturaService(IRestClient restClient,
            II4ProServiceHandler i4ProServiceHandler)
        {
            I4ProServiceHandler = i4ProServiceHandler ?? throw new ArgumentNullException(nameof(i4ProServiceHandler));
        }

        public RetornoServico<I4ProProdutoCoberturaRetorno> Consultar(I4ProProdutoCoberturaRequisicao produtoCoberturaRequisicao)
        {            
            var arquivoJson = JsonConvert.SerializeObject(new I4ProProdutoCoberturaRequisicao
            {
                CodigoProduto = produtoCoberturaRequisicao.CodigoProduto,
                CodigoExternoCobertura = produtoCoberturaRequisicao.CodigoExternoCobertura,
                CodigoExternoProduto = produtoCoberturaRequisicao.CodigoExternoProduto,
                NumeroCobertura = produtoCoberturaRequisicao.NumeroCobertura,
            });

            try
            {
                var parametrosRequest = new RestRequest("Cadastros/ConsultarProdutoCobertura", Method.GET)
                {
                    JsonSerializer = new RestSharpJsonSerializer()
                };

                parametrosRequest.AddHeader("Content-Type", "application/json; charset=utf-8");

                parametrosRequest.AddJsonBody(new I4ProProdutoCoberturaRequisicao {

                });

                var consultaProdutoCoberturaResult = I4ProServiceHandler.Enviar(parametrosRequest);
                
                var resposta = JsonConvert.DeserializeObject<I4ProProdutoCoberturaRetorno>(consultaProdutoCoberturaResult.Content);

                return resposta.CodigoRetorno == I4ProCodigoSucesso ? RetornoServico<I4ProProdutoCoberturaRetorno>.SucessoRetorno(resposta) : RetornoServico<I4ProProdutoCoberturaRetorno>.RetornoErro(ErroEnum.ErroIntegracao, resposta.CodigoRetorno.ToString());
            }
            catch (I4ProException ex)
            {
                return RetornoServico<I4ProProdutoCoberturaRetorno>.RetornoErro(ErroEnum.ErroIntegracao, ex.Message);
            }
            catch (Exception ex)
            {
                return RetornoServico<I4ProProdutoCoberturaRetorno>.RetornoErro(ErroEnum.Excecao, ex.Message);
            }

        }        
    }
}
