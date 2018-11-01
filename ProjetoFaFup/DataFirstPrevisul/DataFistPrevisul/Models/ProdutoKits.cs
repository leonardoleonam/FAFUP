using System;
using System.Collections.Generic;

namespace DataFistPrevisul.Models
{
    public partial class ProdutoKits
    {
        public int PkProdutoKits { get; set; }
        public int IdDeparaProduto { get; set; }
        public string Nome { get; set; }
        public int TipoImpressao { get; set; }
        public string CodFormularios { get; set; }
        public bool Ativo { get; set; }
    }
}
