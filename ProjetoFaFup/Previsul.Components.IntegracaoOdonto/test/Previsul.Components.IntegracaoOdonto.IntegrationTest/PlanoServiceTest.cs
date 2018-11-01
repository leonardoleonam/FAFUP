using System;
using Xunit;
using Previsul.Components.IntegracaoOdonto.Service;
using Previsul.Components.IntegracaoOdonto.Interface;

namespace Previsul.Components.IntegracaoOdonto.Test
{
    public class PlanoServiceTest
    {
        IIntegracaoOdontoService IntegracaoOdontoService { get; }
        public PlanoServiceTest()
        {
            IntegracaoOdontoService = new IntegracaoOdontoService();
        }

        [Fact]
        public void Deve_Listar_Planos()
        {

            var dados = IntegracaoOdontoService.ListarPlanos();
        }


    }
}
