using Application.Integration.PrevisulOnline.Services;
using RestSharp;
using System;
using Xunit;

namespace Previsul.Components.IntegracaoPrevisulOnlineTest
{
    public class PrevisulOnlineServiceTest
    {
        [Fact]
        public void Deve_Gerar_Documento_Condicao_Comercial_Apolice()
        {
            var servico = new PrevisulOnlineService();            

            var dados = servico.Gerar("CONDICAO", 741, 2018);
        }

        [Fact]
        public void Deve_Gerar_Documento_Proposta_Apolice()
        {
            var servico = new PrevisulOnlineService();            

            var dados = servico.Gerar("PROPOSTA", 741, 2018);
        }
    }
}
