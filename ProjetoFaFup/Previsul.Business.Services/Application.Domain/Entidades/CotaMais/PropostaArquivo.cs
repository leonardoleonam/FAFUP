using Application.Domain.Enums;
using System;

namespace Application.Domain.Entidades.CotaMais
{
    public class PropostaArquivo
    {
        public int Id { get; set; }

        public virtual Proposta Proposta { get; set; }

        public int IdProposta { get; set; }

        public DateTime? DataUltimoProcessamento { get; set; }

        public string CodigoProcessamento { get; set; }

        public StatusPropostaArquivoEnum SituacaoProcessamento { get; set; }

        public bool SituacaoUploadProposta { get; set; }

        public bool SituacaoUploadCondicao { get; set; }

        public int? NumeroTentativa { get; set; }

        public bool EhValido { get; set; }

        public bool Inconsistente { get; set; } = false;

        public bool GeradoComSucesso => SituacaoUploadProposta && SituacaoUploadCondicao;

        public bool GeradoComErro => !SituacaoUploadProposta && !SituacaoUploadCondicao;

        public bool GeradoComInconsistencia => !SituacaoUploadProposta || !SituacaoUploadCondicao;        
    }
}