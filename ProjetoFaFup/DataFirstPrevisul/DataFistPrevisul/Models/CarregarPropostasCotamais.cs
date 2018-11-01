using System;
using System.Collections.Generic;

namespace DataFistPrevisul.Models
{
    public partial class CarregarPropostasCotamais
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DtCriacao { get; set; }
        public DateTime? DtUltimoProcessamento { get; set; }
        public int? SitProcessamento { get; set; }
        public string CodProcessamento { get; set; }
        public int? NumTentativa { get; set; }
    }
}
