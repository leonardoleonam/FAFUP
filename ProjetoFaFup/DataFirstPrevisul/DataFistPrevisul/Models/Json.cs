using System;
using System.Collections.Generic;

namespace DataFistPrevisul.Models
{
    public partial class Json
    {
        public int Id { get; set; }
        public int? IdProduto { get; set; }
        public int Ordem { get; set; }
        public string Query { get; set; }
    }
}
