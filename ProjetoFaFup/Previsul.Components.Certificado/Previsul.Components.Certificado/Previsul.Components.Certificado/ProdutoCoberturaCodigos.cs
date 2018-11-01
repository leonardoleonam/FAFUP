using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.Certificado
{
    public class ProdutoCoberturaCodigos
    {

        public ProdutoCoberturaCodigos()
        {

        }

        public int id { get; set; }
        public int? idProduto { get; set; }
        public int? idProdutoCobertura { get; set; }
        public int? idCoberturaCodigos { get; set; }
        public string idPrevisul { get; set; }
        public CoberturasCodigos coberturasCodigos { get; set; }
    }
}
