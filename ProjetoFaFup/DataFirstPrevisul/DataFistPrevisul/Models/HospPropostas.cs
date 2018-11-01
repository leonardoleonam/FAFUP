using System;
using System.Collections.Generic;

namespace DataFistPrevisul.Models
{
    public partial class HospPropostas
    {
        public int Id { get; set; }
        public string Protocolo { get; set; }
        public int CodStatus { get; set; }
        public string Descricao { get; set; }
        public DateTime? DatLog { get; set; }
    }
}
