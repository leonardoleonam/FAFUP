using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.Certificado
{
    public class CoberturasCodigos
    {
        public CoberturasCodigos()
        {

        }

        public int id { get; set; }
        public int? cobertura { get; set; }
        public string idPrevisul { get; set; }
        public int? ramo { get; set; }
        public string descricaoCoberturaExt { get; set; }
        public string descricaoCoberturaPortal { get; set; }
        public bool? ativo { get; set; }
    }
}
