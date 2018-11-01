using System;
using System.Collections.Generic;

namespace DataFistPrevisul.Models
{
    public partial class ProdutoCoberturas
    {
        public int PkProdutoCoberturas { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public int IdDeparaProduto { get; set; }
        public string CodCotamais { get; set; }
        public int CodI4pro { get; set; }
        public string CodSngs { get; set; }
        public string Tipo { get; set; }
        public bool Ativo { get; set; }
        public int CodGrupoI4pro { get; set; }
        public int? PlanoCotamais { get; set; }
        public int CodCobertura { get; set; }
    }
}
