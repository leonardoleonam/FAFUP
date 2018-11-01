using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Previsul.Components.IntegracaoOdonto.Model
{
    [XmlRoot("valorplanorequisicao")]
    public class ValorPlanoRequisicao
    {
        
        public ValorPlanoRequisicao()
        {
        }

        [XmlElement("idPlanoOpcao")]
        public int IdPlanoOpcao { get; set; }

        [XmlElement("quantidadeVidasPlano")]
        public int QuantidadeVidasPlano { get; set; }

        [XmlElement("quantidadeVidasTotal")]
        public int QuantidadeVidasTotal { get; set; }
    }
}
