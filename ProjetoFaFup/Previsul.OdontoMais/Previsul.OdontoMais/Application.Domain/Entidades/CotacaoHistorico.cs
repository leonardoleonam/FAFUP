using System;

namespace Application.Domain.Entidades
{
    public class CotacaoHistorico
    {
        public CotacaoHistorico()
        {
            DtCriacao = DateTime.Now;
        }

        public int Id { get; set; }

        public int IdCotacao { get; set; }

        public Guid GuidCotacaoHistorico { get; set; }

        public virtual Cotacao Cotacao { get; set; }

        public int CodCorretor { get; set; }

        public string CotacaoHistoricoJson { get; set; }

        public DateTime DtCriacao { get; set; }
    }
}