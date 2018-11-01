using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.Certificado
{
    public class DocumentoCertificadoResumo
    {
        public DocumentoCertificadoResumo()
        {

        }

        //public int value { get { return (int)EnumDocumentType.DocDocUsing; } } //Valor referente no EnumDocumentType
        public string name { get { return "DocDocUsing"; } }
        public string templateFileName { get { return "docusingTemplate.html"; } }
        public int firstRowToStartToFill { get { return 0; } }
        public string cpf { get; set; }
        public string telefone1 { get; set; }
        public string vendaOnline { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone2 { get; set; }
        public string estadoCivil { get; set; }
        public string dataNascimento { get; set; }
        public string sexo { get; set; }
        public string PoliticamenteExposta { get; set; }
        public string rendaMensalAuferida { get; set; }
        public string codigoBeneficioINSS { get; set; }
        public string codigoBeneficioINSSDV { get; set; }
        public string limite { get; set; }
        public string beneficiarios0_nome { get; set; }
        public string beneficiarios0_tipo { get; set; }
        public string beneficiarios0_porcentagem { get; set; }
        public string beneficiarios1_nome { get; set; }
        public string beneficiarios1_tipo { get; set; }
        public string beneficiarios1_porcentagem { get; set; }
        public string beneficiarios2_nome { get; set; }
        public string beneficiarios2_tipo { get; set; }
        public string beneficiarios2_porcentagem { get; set; }
        public string beneficiarios3_nome { get; set; }
        public string beneficiarios3_tipo { get; set; }
        public string beneficiarios3_porcentagem { get; set; }
        public string beneficiarios4_nome { get; set; }
        public string beneficiarios4_tipo { get; set; }
        public string beneficiarios4_porcentagem { get; set; }
        public string nomedoSeguro { get; set; }
        public string valor { get; set; }
        public string Cobertura { get; set; }
        public string Franquiadias { get; set; }
        public string PrincipalRS { get; set; }
        public string ConjugeRS { get; set; }
        public string FilhosRS { get; set; }
        public string ASSISTENCIAS1 { get; set; }
        public string ASSISTENCIAS2 { get; set; }

        public string Q1DPSA { get; set; }
        public string Q1DPSADetalhes { get; set; }
        public string Q2DPSA { get; set; }
        public string Q2DPSADetalhes { get; set; }
        public string Q3DPSA { get; set; }
        public string Q3DPSADetalhes { get; set; }
        public string Q4DPSA { get; set; }
        public string Q4DPSADetalhes { get; set; }
        public string Q5DPSA { get; set; }
        public string Q5DPSADetalhes { get; set; }
        public string Q6DPSA { get; set; }
        public string Q6DPSADetalhes { get; set; }
        public string tipoPagamento { get; set; }
        public bool exibeDPSA { get; set; }
        public string banco { get; set; }
        public string diadodebito { get; set; }
        public string agencia { get; set; }
        public string conta { get; set; }
        public string bandeira { get; set; }
        public string ccmm { get; set; }
        public string ccaaaa { get; set; }
    }
}
