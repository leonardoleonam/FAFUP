using Previsul.Components.IntegracaoOdonto.Interface;
using Previsul.Components.IntegracaoOdonto.Model;
using Previsul.Components.IntegracaoOdonto.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Previsul.Components.IntegracaoOdonto.IntegrationTest
{
    public class ValorPlanovidaServiceTest
    {
        IIntegracaoOdontoService IntegracaoOdontoService { get; }

        public ValorPlanovidaServiceTest()
        {
            IntegracaoOdontoService = new IntegracaoOdontoService();
        }

        [Fact]
        public void Deve_Obter_Valor_Plano_Vida()
        {
            Dictionary<string, string> obterValorPlanoVidas = new Dictionary<string, string>();
            obterValorPlanoVidas.Add("idPlanoOpcao", "1");
            obterValorPlanoVidas.Add("quantidadeVidasPlano", "10");
            obterValorPlanoVidas.Add("quantidadeVidasTotal", "10");

            var dados = IntegracaoOdontoService.ObterValorPlano(obterValorPlanoVidas);
        }
    }
}
