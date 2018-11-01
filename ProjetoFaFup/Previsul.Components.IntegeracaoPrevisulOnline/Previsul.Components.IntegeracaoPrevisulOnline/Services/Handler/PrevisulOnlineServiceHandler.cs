using Application.Domain.Entidades;
using Application.Domain.Interfaces.Infrastructure.Integrations.PrevisulOnline.Handler;
using RestSharp;
using System;
using System.Net;

namespace Application.Integration.PrevisulOnline.Services.Handler
{
    public class PrevisulOnlineServiceHandler : IPrevisulOnlineServiceHandler
    {        

        public IRestClient RestClient { get; }        

        public PrevisulOnlineServiceHandler(                       
            IRestClient restClient)
        {                        
            RestClient = restClient ?? throw new ArgumentNullException(nameof(restClient));
        }

        public IRestResponse Enviar(RestRequest restRequest)
        {
            try
            {
                RestClient.BaseUrl = new Uri(ConfiguracaoPbsChaves.PrevisulHost);

                if (bool.Parse(ConfiguracaoPbsChaves.PrevisulProxyHabilitado))
                {
                    var previsulProxy = ConfiguracaoPbsChaves.PrevisulProxy;
                    var previsulPort = int.Parse(ConfiguracaoPbsChaves.PrevisulPort);

                    RestClient.ConfigureWebRequest(wr => wr.Proxy = new WebProxy(previsulProxy, previsulPort)
                    {
                        BypassProxyOnLocal = false
                    });
                }

                restRequest.AddHeader("API-Key", ConfiguracaoPbsChaves.PrevisulApiKey);

                return RestClient.Execute(restRequest);
            }
            catch (Exception ex)
            {                
                throw;
            }            
        }

    }
}
