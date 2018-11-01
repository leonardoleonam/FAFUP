using System;
using System.Collections.Generic;

namespace DataFistPrevisul.Models
{
    public partial class PropostaArquivos
    {
        public int Id { get; set; }
        public int IdProposta { get; set; }
        public DateTime? DtUltimoProcessamento { get; set; }
        public string CodProcessamento { get; set; }
        public int? SitProcessamento { get; set; }
        public int? NumTentativa { get; set; }
        public bool SitUploadProposta { get; set; }
        public bool SitUploadCondicao { get; set; }

        public Propostas IdPropostaNavigation { get; set; }
    }
}
