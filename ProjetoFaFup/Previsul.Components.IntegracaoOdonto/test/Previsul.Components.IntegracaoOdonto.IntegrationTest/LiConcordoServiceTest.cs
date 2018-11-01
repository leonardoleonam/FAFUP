using Previsul.Components.IntegracaoOdonto.Interface;
using Previsul.Components.IntegracaoOdonto.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Previsul.Components.IntegracaoOdonto.IntegrationTest
{
    public class LiConcordoServiceTest
    {
        IIntegracaoOdontoService IntegracaoOdontoService { get; }

        public LiConcordoServiceTest()
        {
            IntegracaoOdontoService = new IntegracaoOdontoService();
        }

        [Fact]
        public void Deve_Obter_Li_Concordo()
        {

            var dados = IntegracaoOdontoService.ObterLiConcordo();
        }
    }
}
