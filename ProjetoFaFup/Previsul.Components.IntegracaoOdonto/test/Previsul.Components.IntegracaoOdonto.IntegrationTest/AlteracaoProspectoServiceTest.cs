using Previsul.Components.IntegracaoOdonto.Interface;
using Previsul.Components.IntegracaoOdonto.Model;
using Previsul.Components.IntegracaoOdonto.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Previsul.Components.IntegracaoOdonto.IntegrationTest
{
    public class AlteracaoProspectoServiceTest
    {
        IIntegracaoOdontoService IntegracaoOdontoService { get; }

        ProspectoAlteracao alteracaoProspecto { get; set; }

        public AlteracaoProspectoServiceTest()
        {
            IntegracaoOdontoService = new IntegracaoOdontoService();
        }

        [Fact]
        public void Deve_Alterar_Dados_Prospecto_Por_Numero_Proposta_Valida()
        {
            //Prospecto
            alteracaoProspecto = new ProspectoAlteracao();
            alteracaoProspecto.CodigoAgencia = "1";
            alteracaoProspecto.CpfCnpj = "28318067000198";
            alteracaoProspecto.IdCorteFaturamento = 2;
            alteracaoProspecto.Indicador = "Teste";
            alteracaoProspecto.InicioVigencia = DateTime.Now; //.ToString("yyyy-MM-dd");
            alteracaoProspecto.NomeFantasia = "TESTE WS III";
            alteracaoProspecto.RazaoSocial = "TESTE WS III";
            alteracaoProspecto.QuantidadeVidas = 10;
            alteracaoProspecto.NumeroProposta = 100038841;


            //Endereco
            alteracaoProspecto.Endereco = new Endereco { Bairro = "PIRITUBA", Cep = "02870080", Cidade = "SAO PAULO", Complemento = "CASA", Contato = "TESTE", Email = "wilkner.silva@odontoempresas.com.br", Logradouro = "Rua Terste", Numero = "1234", TelefoneCelular = "11981083231", TelefoneComercial = "1139924195", Uf = "SP" };

            //Endereco Carteirinha
            alteracaoProspecto.EnderecoCarteirinha = new Endereco { Bairro = "CARRAO", Cep = "03420000", Cidade = "SAO PAULO", Complemento = "CASA", Contato = "TESTE II", Email = "teste@email.com", Logradouro = "Logradouro teste", Numero = "987", TelefoneCelular = "11987564213", TelefoneComercial = "1139924195", Uf = "SP" };            

            //Planos
            var Planos = new PlanosEscolhas();
            Planos = new PlanosEscolhas { IdPlanoOpcao = 1, QtdeVidas = 10 };
            alteracaoProspecto.PlanosEscolhas = Planos;

            //Corretor
            alteracaoProspecto.Corretores = new List<Corretor>();
            alteracaoProspecto.Corretores.Add(new Corretor { CpfCnpj = "35124461837", Email = "wilkner@gmail.com", IdOpcaoComissao = 1, NomeCorretor = "WILKNER TESTE WS" });            

            var dados = IntegracaoOdontoService.Alterar(alteracaoProspecto);
        }
    }
}
