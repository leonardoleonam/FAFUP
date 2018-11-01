using Application.Domain;
using Application.Domain.Entidades;
using Application.Domain.Interfaces;
using Application.Domain.Interfaces.Infrastructure;
using Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro;
using Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro.Contratos;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;

namespace Application.Integration.I4Pro.Services
{
    public class AutenticadorTokenService : IAutenticadorTokenService
    {       
        public IRestClient RestClient { get; }
        
        public AutenticadorTokenService(            
            IRestClient restClient)
        {           
            RestClient = restClient ?? throw new ArgumentNullException(nameof(restClient));
        }

        public static I4ProToken I4ProToken { get; set; }

        public RetornoServico<I4ProToken> BuscarTokenAcesso()
        {
            if (I4ProToken == null || I4ProToken.TokenEhValido == false)
            {
                var request = new RestRequest("ws/token", Method.POST);
                request.AddHeader("Authorization", $"Basic {ConfiguracaoPbsChaves.I4ProBasicToken}");
                request.AddHeader("Content-Type", "application/json; charset=utf-8");
                request.AddJsonBody(new { });

                if (bool.Parse(ConfiguracaoPbsChaves.PrevisulProxyHabilitado))
                {
                    var previsulProxy = ConfiguracaoPbsChaves.PrevisulProxy;
                    var previsulPort = int.Parse(ConfiguracaoPbsChaves.PrevisulPort);

                    RestClient.ConfigureWebRequest(wr => wr.Proxy = new WebProxy(previsulProxy, previsulPort)
                    {
                        BypassProxyOnLocal = false
                    });
                }

                RestClient.BaseUrl = new Uri(ConfiguracaoPbsChaves.I4ProHost);
                var gerarToken = RestClient.Execute(request);                

                I4ProToken = JsonConvert.DeserializeObject<I4ProToken>(gerarToken.Content);
            }

            return RetornoServico<I4ProToken>.SucessoRetorno(I4ProToken);
        }

        public void LimparToken()
        {
            I4ProToken = null;
        }
    }
}
