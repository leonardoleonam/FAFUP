using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.Certificado
{
    public class DocumentoCertificado
    {
        public DocumentoCertificado()
        {

        }

        //public int value { get { return (int)EnumDocumentType.DocCertificado; } } //Valor referente no EnumDocumentType
        public int value { get { return 1; } } //Valor referente no EnumDocumentType
        public string name { get { return "DocCertificado"; } }
        public string templateFileName { get { return "certificadoTemplate.html"; } }
        public int firstRowToStartToFill { get { return 0; } }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string dataNacimento { get; set; }
        public string codigoSegurado { get; set; }
        public string nomeConjuge { get; set; }
        public string cpfConjuge { get; set; }
        public string dataNacimentoConjuge { get; set; }
        public string codigoSeguradoConjuge { get; set; }
        public string endereço { get; set; }
        public string cep { get; set; }
        public string cidadeeUF { get; set; }
        public string Estipulante { get; set; }
        public string EstipulanteCNPJ { get; set; }
        public string enderecoEstipulante { get; set; }
        public string telefoneEstipulante { get; set; }
        public string remuneracaoEstipulante { get; set; }
        public string SubestipulanteConsignante { get; set; }
        public string SubestipulanteConsignanteCNPJ { get; set; }
        public string enderecoSubestipulanteConsignante { get; set; }
        public string telefoneSubestipulanteConsignante { get; set; }
        public string remuneracaoSubestipulanteConsignante { get; set; }
        public string Coseguradora { get; set; }
        public string CoseguradoraCNPJ { get; set; }
        public string CcseguradoraCodigoSUSP { get; set; }
        public string Proposta { get; set; }
        public string Apolice { get; set; }
        public string Certificado { get; set; }
        public string iniciodeVigencia { get; set; }
        public string fimdeVigencia { get; set; }
        public string Cobertura { get; set; }
        public string Franquiadias { get; set; }
        public string PrincipalRS { get; set; }
        public string ConjugeRS { get; set; }
        public string FilhosRS { get; set; }
        public string ASSISTENCIAS1 { get; set; }
        public string ASSISTENCIAS2 { get; set; }
        public string NomeBene1 { get; set; }
        public string ParentescoBene1 { get; set; }
        public string ProporcaoBene1 { get; set; }
        public string NomeBeneConj1 { get; set; }
        public string ParentescoBeneConj1 { get; set; }
        public string ProporcaoBeneConj1 { get; set; }
        public string DatadeEmissao { get; set; }
        public string FormadePagamento { get; set; }
        public string IOFRS { get; set; }
        public string PremioLiquidoRS { get; set; }
        public string PremioTotalRS { get; set; }
        public string PeriodicidadedeCobranca { get; set; }
        public string Corretor { get; set; }
        public string RegSUSEPCorretor { get; set; }
        public string CodInternodoCorretor { get; set; }
        public string ExcedenteTec { get; set; }
        public string numeroSorte { get; set; }
        public string Periodicidade { get; set; }
    }
}
