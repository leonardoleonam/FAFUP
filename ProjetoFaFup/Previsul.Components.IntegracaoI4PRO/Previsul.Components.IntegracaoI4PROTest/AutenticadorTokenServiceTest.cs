using Application.Domain.Entidades;
using Application.Domain.Interfaces;
using Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro;
using Application.Integration.I4Pro.Services;
using RestSharp;
using Xunit;

namespace Previsul.Components.IntegracaoI4PROTest
{
    public class AutenticadorTokenServiceTest
    {
        IAutenticadorTokenService AutenticadorTokenService { get; }

        public AutenticadorTokenServiceTest()
        {
           
        }

        [Fact]
        public void Deve_Gerar_Novo_Token()
        {            
            var servico = new AutenticadorTokenService( new RestClient());

            servico.LimparToken();           

            var dados = servico.BuscarTokenAcesso();
        }       
    }
}
