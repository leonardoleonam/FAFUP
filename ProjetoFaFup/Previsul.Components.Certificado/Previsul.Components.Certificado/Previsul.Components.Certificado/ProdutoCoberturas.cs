using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.Certificado
{
    public class ProdutoCoberturas
    {
        public ProdutoCoberturas()
        {

        }

        public int id { get; set; }
        public int? idProduto { get; set; }
        public string descricao { get; set; }
        public string sigla { get; set; }
        public DateTime? dataCriacao { get; set; }
        public List<ProdutoCoberturaCodigos> produtoCoberturaCodigos { get; set; }
        public bool? ativo { get; set; }
    }
}
