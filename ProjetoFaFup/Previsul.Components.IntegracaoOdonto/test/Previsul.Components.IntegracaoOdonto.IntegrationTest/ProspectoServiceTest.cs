using System;
using Xunit;
using Previsul.Components.IntegracaoOdonto.Service;
using Previsul.Components.IntegracaoOdonto.Interface;
using Previsul.Components.IntegracaoOdonto.Model;

namespace Previsul.Components.IntegracaoOdonto.Test
{
    public class ProspectoServiceTest
    {

        IIntegracaoOdontoService IntegracaoOdontoService { get; }
        Prospecto ProspectoDTO { get; set; }
        public ProspectoServiceTest()
        {
            IntegracaoOdontoService = new IntegracaoOdontoService();

            //Prospecto
            ProspectoDTO = new Prospecto();
            ProspectoDTO.CodigoAgencia = "1";
            ProspectoDTO.CpfCnpj = "35124461837";
            ProspectoDTO.IdCorteFaturamento = 2;
            ProspectoDTO.Indicador = "Teste";
            ProspectoDTO.InicioVigencia = DateTime.Now.ToString("yyyy-MM-dd");
            ProspectoDTO.nomeFantasia = "TESTE WS II";
            ProspectoDTO.RazaoSocial = "TESTE WS II";
            ProspectoDTO.QtdVidas = 10;


            //Endereco
            ProspectoDTO.Endereco = new Endereco { Bairro = "PIRITUBA", Cep = "02870080", Cidade = "SAO PAULO", Complemento = "CASA", Contato = "TESTE", Email = "wilkner.silva@odontoempresas.com.br", Logradouro = "Rua Terste", Numero = "1234", TelefoneCelular = "11981083231", TelefoneComercial = "1139924195", Uf = "SP" };

            //Planos
            var Planos = new PlanosEscolhas[1];
            Planos[0] = new PlanosEscolhas { IdPlanoOpcao = 1, QtdeVidas = 10 };
            ProspectoDTO.PlanosEscolhas = Planos;

            //Corretor
            var Corretores = new Corretor[1];
            Corretores[0] = new Corretor { CpfCnpj = "35124461837", Email = "wilkner@gmail.com", IdOpcaoComissao = 1, NomeCorretor = "WILKNER TESTE WS" };
            ProspectoDTO.Corretores = Corretores;

        }
        [Fact]
        public void Deve_Criar_Prospecto()
        {

            IntegracaoOdontoService.IncluirProspecto(ProspectoDTO);
        }

        [Fact]
        public void NaoDeve_Criar_Prospecto()
        {
            ProspectoDTO.PlanosEscolhas = null;
            IntegracaoOdontoService.IncluirProspecto(ProspectoDTO);
        }

    }
}
