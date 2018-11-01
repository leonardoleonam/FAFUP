using Application.Integration.I4Pro.Services;
using Application.Integration.I4Pro.Services.Handler;
using Previsul.Components.IntegracaoI4PRO.Interfaces;
using Previsul.Components.IntegracaoI4PRO.Objetos_Requisicao;
using Previsul.Components.IntegracaoI4PRO.Services;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Previsul.Components.IntegracaoI4PROTest
{
    public class ProdutoCoberturaServiceTest
    {
        IProdutoCoberturaService ProdutoCoberturaService { get; }

        public ProdutoCoberturaServiceTest()
        {

        }

        [Fact]
        public void Deve_Recuperar_Produtos_Cobertura()
        {
            var handler = new I4ProServiceHandler(new AutenticadorTokenService(new RestClient()), new RestClient());
            var servico = new ProdutoCoberturaService(new RestClient(), handler);
            
            var dados = servico.Consultar(new I4ProProdutoCoberturaRequisicao());
        }
    }
}
