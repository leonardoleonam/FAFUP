using Previsul.Components.IntegracaoOdonto.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Previsul.Components.IntegracaoOdonto.Model
{    
    [XmlRoot("prospecto")]
    public class ProspectoPesquisa
    {       
        [XmlElement("codigoAgencia")]
        public string CodigoAgencia;

        [XmlElement("cpfCnpj")]
        public string CpfCnpj;

        [XmlElement("cpfCnpjCorretor")]
        public string CpfCnpjCorretor;        

        [XmlElement("dataPropostaAte")]
        public string DataPropostaAte;

        [XmlElement("dataPropostaDe")]
        public string DataPropostaDe;

        [XmlElement("indicador")]
        public string Indicador;

        [XmlElement("nomeFantasia")]
        public string NomeFantasia;

        [XmlElement("nomeSituacaoProspecto")]
        public string NomeSituacaoProspecto;

        [XmlElement("numeroProposta")]
        public string NumeroProposta;

        [XmlElement("primeiroRegistro")]
        public string PrimeiroRegistro;

        [XmlElement("quantidadeMaxRegistros")]
        public string QuantidadeMaxRegistros;

        [XmlElement("razaoSocial")]
        public string RazaoSocial;        
    }
}
