using Previsul.Components.IntegracaoOdonto.Interface;
using Previsul.Components.IntegracaoOdonto.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Previsul.Components.IntegracaoOdonto.IntegrationTest
{
    public class DetalheProspectoServiceTest
    {
        IIntegracaoOdontoService IntegracaoOdontoService { get; }
        public DetalheProspectoServiceTest()
        {
            IntegracaoOdontoService = new IntegracaoOdontoService();
        }

        [Fact]
        public void Deve_Detalhar_Prospecto_Por_Numero_Proposta_Valida()
        {
            var numeroProposta = "100038841";

            Dictionary<string, string> obterDetalheProspecto = new Dictionary<string, string>();
            obterDetalheProspecto.Add("numeroProposta", numeroProposta);            

            var dados = IntegracaoOdontoService.DetalharProspecto(obterDetalheProspecto);
        }
    }
}
