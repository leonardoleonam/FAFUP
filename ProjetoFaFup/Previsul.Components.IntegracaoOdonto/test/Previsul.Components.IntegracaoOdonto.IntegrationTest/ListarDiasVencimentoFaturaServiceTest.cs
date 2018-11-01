using Previsul.Components.IntegracaoOdonto.Interface;
using Previsul.Components.IntegracaoOdonto.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Previsul.Components.IntegracaoOdonto.IntegrationTest
{
    public class ListarDiasVencimentoFaturaServiceTest
    {
        IIntegracaoOdontoService IntegracaoOdontoService { get; }

        public ListarDiasVencimentoFaturaServiceTest()
        {
            IntegracaoOdontoService = new IntegracaoOdontoService();
        }

        [Fact]
        public void Deve_Listar_Dias_Vencimento_Fatura()
        {

            var dados = IntegracaoOdontoService.ListarDiasVencimentoFatura();
        }
    }
}
