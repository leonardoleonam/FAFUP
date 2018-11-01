using Previsul.Components.IntegracaoOdonto.Interface;
using Previsul.Components.IntegracaoOdonto.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Previsul.Components.IntegracaoOdonto.IntegrationTest
{
    public class ListarOpcoesComissaoCorretorServiceTest
    {
        IIntegracaoOdontoService IntegracaoOdontoService { get; }
        public ListarOpcoesComissaoCorretorServiceTest()
        {
            IntegracaoOdontoService = new IntegracaoOdontoService();
        }

        [Fact]
        public void Deve_Listar_Opcoes_Comissao_Corretor()
        {
            var dados = IntegracaoOdontoService.ListarOpcoesComissaoCorretor();
        }
    }
}
