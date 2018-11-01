using Newtonsoft.Json;
using System.Collections.Generic;

namespace Previsul.Components.IntegracaoIntouchws.Model
{
    #region Classes

    public class LocalizaPessoas
    {

        [JsonProperty("CADASTROUNIT")]
        public CadastroUnit CadastroUnit { get; set; }

        [JsonProperty("DADOS_CADASTRAIS")]
        public DadosCadastrais DadosCadastrais { get; set; }

        [JsonProperty("TELEFONES")]
        public List<Telefones> Telefones { get; set; }

        [JsonProperty("ENDERECOS")]
        public List<Enderecos> Enderecos { get; set; }

        [JsonProperty("PARTICIPACAO_EMPRESA")]
        public ParticipacaoEmpresa ParticipacaoEmpresa { get; set; }

        [JsonProperty("EMAILS")]
        public List<Emails> Emails { get; set; }

        [JsonProperty("SOCIOS")]
        public List<Socios> Socios { get; set; }
    }

    public class CadastroUnit
    {
        [JsonProperty("DOCUMENTO")]
        public string Documento;

        [JsonProperty("NOME")]
        public string Nome;

        [JsonProperty("ID_UNIT")]
        public string ID_Unit;
    }

    public class DadosCadastrais
    {
        /* DADOS DA PESSOA JURIDICA */

        [JsonProperty("CNPJ")]
        public string CNPJ;

        [JsonProperty("RAZAO")]
        public string RazaoSocial;

        [JsonProperty("NOME_FANTASIA")]
        public string NomeFantasia;

        [JsonProperty("DT_ABERTURA")]
        public string DataAbertura;

        [JsonProperty("COD_CNAE")]
        public string CodigoCNAE;

        [JsonProperty("DESCRICAO_CNAE")]
        public string DescricaoCNAE;

        [JsonProperty("QTD_FUNCIONARIOS")]
        public string QuantidadeFuncionarios;

        [JsonProperty("DESCR_SITUACAO_CAD")]
        public string SituacaoCadastral;

        [JsonProperty("NJUR")]
        public string NJUR;

        [JsonProperty("NATUREZA")]
        public string Natureza;

        [JsonProperty("PORTE")]
        public string Porte;

        [JsonProperty("QTD_PROP")]
        public string QTD_PROP;


        /* DADOS DA PESSOA FISICA */

        [JsonProperty("CPF")]
        public string CPF;

        [JsonProperty("NOME")]
        public string Nome;

        [JsonProperty("NOME_ULTIMO")]
        public string NomeUltimo;

        [JsonProperty("SEXO")]
        public string Sexo;

        [JsonProperty("NOME_MAE")]
        public string NomeMae;

        [JsonProperty("DATANASC")]
        public string DataNascimento;

        [JsonProperty("IDADE")]
        public string Idade;

        [JsonProperty("SIGNO")]
        public string Signo;
    }

    public class Telefones
    {
        [JsonProperty("RANKING")]
        public string Ranking;

        [JsonProperty("TELEFONE")]
        public string Telefone;

        [JsonProperty("TELEFONE_VALIDO")]
        public string TelefoneValido;

        [JsonProperty("ORIGEM")]
        public string Origem;

        [JsonProperty("PERMISSAO_MARKET")]
        public string PermissaoMarket;

        [JsonProperty("ASSINANTE")]
        public bool Assinante;

        [JsonProperty("OPERADORA")]
        public string Operadora;

        [JsonProperty("TIPO")]
        public string Tipo;
    }

    public class Enderecos
    {
        [JsonProperty("RANKING")]
        public string Ranking;

        [JsonProperty("LOGRADOURO")]
        public string Logradouro;

        [JsonProperty("NUMERO")]
        public string Numero;

        [JsonProperty("COMPLEMENTO")]
        public string Complemento;

        [JsonProperty("BAIRRO")]
        public string Bairro;

        [JsonProperty("CEP")]
        public string Cep;

        [JsonProperty("CIDADE")]
        public string Cidade;

        [JsonProperty("UF")]
        public string UF;
    }

    public class ParticipacaoEmpresa
    {
        [JsonProperty("NOME")]
        public string Nome;

        [JsonProperty("ID_UNIT")]
        public string ID_Unit;

        [JsonProperty("DOCUMENTO")]
        public string Documento;

        [JsonProperty("PCT_PARTICIPACAO")]
        public string PercentualParticipacao;

        [JsonProperty("DATA_ENTRADA")]
        public string DataEntrada;
    }

    public class Emails
    {
        [JsonProperty("RANKING")]
        public string Ranking;

        [JsonProperty("EMAIL")]
        public string Email;

        [JsonProperty("PARTICULAR")]
        public string Particular;
    }

    public class Socios
    {
        [JsonProperty("ID_UNIT")]
        public string ID_Unit;

        [JsonProperty("DOCUMENTO")]
        public string Documento;

        [JsonProperty("NOME")]
        public string Nome;

        [JsonProperty("PCT_PARTICIPACAO")]
        public string PercentualParticipacao;

        [JsonProperty("DATA_ENTRADA")]
        public string DataEntrada;

        [JsonProperty("CARGO_SOCIO")]
        public string CargoSocio;
    }

    #endregion Classes
}
