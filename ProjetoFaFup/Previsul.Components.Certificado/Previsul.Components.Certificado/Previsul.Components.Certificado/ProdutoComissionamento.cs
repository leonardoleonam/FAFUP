using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.Certificado
{
    public class ProdutoComissionamento
    {
        public int id { get; set; }
        public int? idProduto { get; set; }
        public string descricao { get; set; }
        public decimal? parcela1CC { get; set; }
        public decimal? parcela1PL { get; set; }
        public decimal? parcela1AG { get; set; }
        public decimal? parcela2AG { get; set; }
        public decimal? parcela2CC { get; set; }
        public decimal? parcela2PL { get; set; }
        public decimal? parcela3AG { get; set; }
        public decimal? parcela3CC { get; set; }
        public decimal? parcela3PL { get; set; }
        public decimal? parcela4AG { get; set; }
        public decimal? parcela4CC { get; set; }
        public decimal? parcela4PL { get; set; }
        public DateTime? dataCriacao { get; set; }
        public bool? ativo { get; set; }
    }
}
