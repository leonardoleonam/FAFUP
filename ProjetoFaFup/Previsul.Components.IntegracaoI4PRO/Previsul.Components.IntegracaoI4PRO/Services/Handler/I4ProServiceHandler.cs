using Application.Domain.Entidades;
using Application.Domain.Interfaces;
using Application.Domain.Interfaces.Infrastructure;
using Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro;
using Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro.Handler;
using RestSharp;
using System;
using System.Net;

namespace Application.Integration.I4Pro.Services.Handler
{
    public class I4ProServiceHandler : II4ProServiceHandler
    {        
        public IRestClient RestClient { get; }

        public AutenticadorTokenService AutenticadorTokenService { get; set; }

        private const int MaximoRetentativa = 1;

        public I4ProServiceHandler(            
            IAutenticadorTokenService AutenticadorTokenService,

            IRestClient restClient)
        {            
            AutenticadorTokenService = new AutenticadorTokenService(new RestClient()); ;
            RestClient = restClient ?? throw new ArgumentNullException(nameof(restClient));
        }

        public IRestResponse Enviar(RestRequest restRequest)
        {
            try
            {
                if (bool.Parse(ConfiguracaoPbsChaves.PrevisulProxyHabilitado))
                {
                    var previsulProxy = ConfiguracaoPbsChaves.PrevisulProxy;
                    var previsulPort = int.Parse(ConfiguracaoPbsChaves.PrevisulPort);

                    RestClient.ConfigureWebRequest(wr => wr.Proxy = new WebProxy(previsulProxy, true)
                    {
                        Credentials = CredentialCache.DefaultCredentials
                    });
                }

                restRequest.AddHeader("Authorization", "Bearer " + BuscarToken());

                RestClient.BaseUrl = new Uri(ConfiguracaoPbsChaves.I4ProHost);

                return RestClient.Execute(restRequest);
            }
            catch (Exception ex)
            {
                throw;
            }            
        }

        private string BuscarToken(int retentativa = 0)
        {
            AutenticadorTokenService = new AutenticadorTokenService(new RestClient());
            var buscarTokenAcesso = AutenticadorTokenService.BuscarTokenAcesso();

            if (buscarTokenAcesso.Sucesso)
            {
                return buscarTokenAcesso.ObjetoRetorno.Token;
            }

            AutenticadorTokenService.LimparToken();

            if (retentativa >= MaximoRetentativa)
            {
                return string.Empty;
            }

            return BuscarToken(MaximoRetentativa);
        }
    }
}
