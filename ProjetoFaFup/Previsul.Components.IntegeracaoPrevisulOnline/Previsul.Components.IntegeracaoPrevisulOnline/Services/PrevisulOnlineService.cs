using Application.Domain;
using Application.Domain.Interfaces.Infrastructure.Integrations.PrevisulOnline;
using Application.Domain.Interfaces.Infrastructure.Integrations.PrevisulOnline.Contratos;
using Application.Domain.Interfaces.Infrastructure.Integrations.PrevisulOnline.Handler;
using Application.Integration.PrevisulOnline.Services.Handler;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace Application.Integration.PrevisulOnline.Services
{
    public class PrevisulOnlineService : IPrevisulOnlineService
    {
        public IPrevisulOnlineServiceHandler PrevisulOnlineServiceHandler { get; }

        IRestClient RestClient { get; }

        public PrevisulOnlineService()
        {
            RestClient = new RestClient();

            PrevisulOnlineServiceHandler = new PrevisulOnlineServiceHandler(RestClient); 
        }

        public PrevisulOnlineGeradorDocumentoRetorno Gerar(string tipoDocumento, int protocolo, int ano)
        {
            var parametrosRequisicao = new RestRequest("documentos", Method.POST);
            parametrosRequisicao.AddJsonBody(new { TIPO_DOCUMENTO = tipoDocumento, PROTOCOLO = protocolo, ANO = ano });
            parametrosRequisicao.AddHeader("Cache-Control", "no-cache");
            parametrosRequisicao.AddHeader("Content-Type", "application/json");

            var retornoServico = PrevisulOnlineServiceHandler.Enviar(parametrosRequisicao);
            
            var retornoDeserializado =  JsonConvert.DeserializeObject<PrevisulOnlineGeradorDocumentoRetorno>(retornoServico.Content);

            return retornoDeserializado;
        }
    }
}
