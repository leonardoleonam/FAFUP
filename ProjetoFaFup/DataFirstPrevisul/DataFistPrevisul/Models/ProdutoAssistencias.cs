using System;
using System.Collections.Generic;

namespace DataFistPrevisul.Models
{
    public partial class ProdutoAssistencias
    {
        public int PkProdutoAssistencias { get; set; }
        public string Descricao { get; set; }
        public int IdDeparaProduto { get; set; }
        public string CodCotamais { get; set; }
        public int CodI4pro { get; set; }
        public string CodSngs { get; set; }
        public bool Ativo { get; set; }
        public int CodGrupoI4pro { get; set; }
        public int? PlanoCotamais { get; set; }
        public int CodAssistencia { get; set; }
    }
}
