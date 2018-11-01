using Previsul.Components.IntegracaoOdonto.Interface;
using Previsul.Components.IntegracaoOdonto.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Previsul.Components.IntegracaoOdonto.IntegrationTest
{
    public class ObterArquivoPropostaServiceTest
    {
        IIntegracaoOdontoService IntegracaoOdontoService { get; }
        public ObterArquivoPropostaServiceTest()
        {
            IntegracaoOdontoService = new IntegracaoOdontoService();
        }

        [Fact]
        public void Deve_Obter_Arquivo_Proposta_Por_Numero_Proposta_Valido()
        {
            Dictionary<string, string> numeroProposta = new Dictionary<string, string>();
            numeroProposta.Add("numeroProposta", "100038841");


            var dados = IntegracaoOdontoService.ObterArquivo(numeroProposta);
        }

    }
}
