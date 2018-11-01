using System;
using System.Collections.Generic;

namespace DataFistPrevisul.Models
{
    public partial class ProdutoAssistencias1
    {
        public int IdProdutoAssistencias { get; set; }
        public int IdProduto { get; set; }
        public int CodAssistencia { get; set; }
        public string Descricao { get; set; }
        public string Sistema { get; set; }
        public int CodGrupo { get; set; }
        public int? Plano { get; set; }
        public string CodCotamais { get; set; }
        public bool Ativo { get; set; }

        public Produtos1 IdProdutoNavigation { get; set; }
    }
}
