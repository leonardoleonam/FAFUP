using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Previsul.Components.IntegracaoOdonto.Model
{
    [XmlRoot("prospecto")]
    public class Prospecto
    {
        [XmlElement("codigoAgencia")]
        public string CodigoAgencia;

        [XmlElement("corretores")]
        public Corretor[] Corretores;

        [XmlElement("cpfCnpj")]
        public string CpfCnpj;

        [XmlElement("endereco")]
        public Endereco Endereco;

        [XmlElement("idCorteFaturamento")]
        public long IdCorteFaturamento;

        [XmlElement("indicador")]
        public string Indicador;

        [XmlElement("inicioVigencia")]
        public string InicioVigencia;

        [XmlElement("nomeFantasia")]
        public string nomeFantasia;

        [XmlElement("planosEscolhas")]
        public PlanosEscolhas[] PlanosEscolhas;

        [XmlElement("quantidadeVidas")]
        public long QtdVidas;

        [XmlElement("razaoSocial")]
        public string RazaoSocial;
    }


    public class Corretor
    {
        [XmlElement("cpfCnpj")]

        public string CpfCnpj;

        [XmlElement("email")]
        public string Email;

        [XmlElement("idOpcaoComissao")]
        public int IdOpcaoComissao;

        [XmlElement("nomeCorretor")]
        public string NomeCorretor;
    }

    public class Endereco
    {
        [XmlElement("bairro")]
        public string Bairro;

        [XmlElement("cep")]
        public string Cep;

        [XmlElement("cidade")]
        public string Cidade;

        [XmlElement("complemento")]
        public string Complemento;

        [XmlElement("contato")]
        public string Contato;

        [XmlElement("email")]
        public string Email;

        [XmlElement("logradouro")]
        public string Logradouro;

        [XmlElement("numero")]
        public string Numero;

        [XmlElement("telefoneCelular")]
        public string TelefoneCelular;

        [XmlElement("telefoneComercial")]
        public string TelefoneComercial;

        [XmlElement("uf")]
        public string Uf;
    }

    public class PlanosEscolhas
    {
        [XmlElement("idPlanoOpcao")]
        public int IdPlanoOpcao;
        [XmlElement("qtdeVidas")]
        public int QtdeVidas;

    }
}
