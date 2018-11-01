using Previsul.Components.IntegracaoOdonto.Interface;
using Previsul.Components.IntegracaoOdonto.Model;
using Previsul.Components.IntegracaoOdonto.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Previsul.Components.IntegracaoOdonto.IntegrationTest
{
    public class PesquisaProspectoServiceTest
    {
        IIntegracaoOdontoService IntegracaoOdontoService { get; }

        public PesquisaProspectoServiceTest()
        {
            IntegracaoOdontoService = new IntegracaoOdontoService();
        }

        [Fact]
        public void Deve_Pesquisar_Prospecto_Por_Numero_Proposta_Valida()
        {
            var prospectoPesquisa = new ProspectoPesquisa
            {
                NumeroProposta = "100038841"
               
            };           

            var dados = IntegracaoOdontoService.PesquisarProspecto(prospectoPesquisa);
        }

        [Fact]
        public void Deve_Pesquisar_Prospecto_Por_Razao_Social_Empresa_Valida()
        {
            var prospectoPesquisa = new ProspectoPesquisa
            {
                RazaoSocial = "TESTE"

            };

            var dados = IntegracaoOdontoService.PesquisarProspecto(prospectoPesquisa);
        }

    }
}
