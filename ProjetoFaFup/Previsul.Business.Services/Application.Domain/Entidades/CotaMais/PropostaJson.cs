using System;

namespace Application.Domain.Entidades.CotaMais
{
    public class PropostaJson
    {
        public int Id { get; set; }

        public virtual Proposta Proposta { get; set; }

        public int IdProposta { get; set; }

        public string JsonRequest { get; set; }

        public string JsonResponse { get; set; }

        public DateTime DtCriacao { get; set; }

        public int SitProcessamento { get; set; }

        public string CodProcessamento { get; set; }
    }
}