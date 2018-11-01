using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Previsul.Components.IntegracaoOdonto.Model
{
    [XmlRoot("prospecto")]
    public class ProspectoAlteracao
    {
        [XmlElement("codigoAgencia")]
        public string CodigoAgencia { get; set; }

        [XmlElement("corretores")]
        public List<Corretor> Corretores { get; set; }

        [XmlElement("cpfCnpj")]
        public string CpfCnpj { get; set; }

        [XmlElement("endereco")]
        public Endereco Endereco { get; set; }

        [XmlElement("enderecoCarteirinha")]
        public Endereco EnderecoCarteirinha { get; set; }

        [XmlElement("idCorteFaturamento")]
        public long IdCorteFaturamento { get; set; }

        [XmlElement("indicador")]
        public string Indicador { get; set; }

        [XmlElement("inicioVigencia")]
        public DateTime InicioVigencia;

        [XmlElement("nomeFantasia")]
        public string NomeFantasia { get; set; }
        
        [XmlElement("numeroProposta")]
        public long NumeroProposta { get; set; }

        [XmlElement("planosEscolhas")]
        public PlanosEscolhas PlanosEscolhas { get; set; }

        [XmlElement("quantidadeVidas")]
        public long QuantidadeVidas { get; set; }

        [XmlElement("razaoSocial")]
        public string RazaoSocial { get; set; }
    }



    

    

    

    
}
