using System;
using System.Collections.Generic;

namespace DataFistPrevisul.Models
{
    public partial class Produtos
    {
        public Produtos()
        {
            Propostas = new HashSet<Propostas>();
        }

        public int PkProduto { get; set; }
        public int CodProduto { get; set; }
        public string Descricao { get; set; }
        public string CodCotamais { get; set; }
        public int CodI4pro { get; set; }
        public bool Ativo { get; set; }

        public ICollection<Propostas> Propostas { get; set; }
    }
}
