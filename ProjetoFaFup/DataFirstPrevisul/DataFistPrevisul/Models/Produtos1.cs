using System;
using System.Collections.Generic;

namespace DataFistPrevisul.Models
{
    public partial class Produtos1
    {
        public Produtos1()
        {
            ProdutoAssistencias1 = new HashSet<ProdutoAssistencias1>();
            ProdutoCoberturas1 = new HashSet<ProdutoCoberturas1>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public string CodCotamais { get; set; }

        public ICollection<ProdutoAssistencias1> ProdutoAssistencias1 { get; set; }
        public ICollection<ProdutoCoberturas1> ProdutoCoberturas1 { get; set; }
    }
}
