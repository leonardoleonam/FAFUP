using System;
using System.Collections.Generic;

namespace DataFistPrevisul.Models
{
    public partial class PropostaJson
    {
        public int Id { get; set; }
        public int IdProposta { get; set; }
        public string JsonRequest { get; set; }
        public string JsonResponse { get; set; }
        public DateTime DtCriacao { get; set; }
        public int SitProcessamento { get; set; }
        public string CodProcessamento { get; set; }

        public Propostas IdPropostaNavigation { get; set; }
    }
}
