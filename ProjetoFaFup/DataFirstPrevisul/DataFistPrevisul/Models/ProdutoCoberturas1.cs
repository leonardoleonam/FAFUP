using System;
using System.Collections.Generic;

namespace DataFistPrevisul.Models
{
    public partial class ProdutoCoberturas1
    {
        public int IdProdutoCoberturas { get; set; }
        public int IdProduto { get; set; }
        public string CodCobertura { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public string Sistema { get; set; }
        public int CodGrupo { get; set; }
        public string Tipo { get; set; }
        public int? Plano { get; set; }
        public string CodCotamais { get; set; }
        public bool Ativo { get; set; }

        public Produtos1 IdProdutoNavigation { get; set; }
    }
}
