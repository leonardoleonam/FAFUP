using Previsul.Utils.WebServices;
using System.Collections.Generic;
using Xunit;

namespace Previsul.Utils.Test.Utils
{
    public class UtilsTest
    {
        public class Teste
        {
            public int id { get; set; }
            public string descricao { get; set; }
        }

        private readonly Teste teste;

        public UtilsTest()
        {
            teste = new Teste()
            {
                id = 1,
                descricao = "teste"
            };
        }

        [Fact]
        public void Deve_Retonar_Um_Xml()
        {
            string xmlEsperado = "<Teste><id>1</id><descricao>teste</descricao></Teste>";
            string xmlRetornado = teste.SerializeXml().Replace("\r\n","").Replace(" ", "").Trim();
            Assert.Equal(xmlEsperado, xmlRetornado);
        }

        [Fact]
        public void Deve_Gerar_Um_Xml()
        {
            string xmlEsperado = "<id>1</id><descricao>teste</descricao>";

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("id", "1");
            dic.Add("descricao", "teste");

            string xmlRetornado = dic.GerarXml().Replace("\r\n", "").Replace(" ", "").Trim(); ;
            Assert.Equal(xmlEsperado, xmlRetornado);
        }
    }
}
