using System.ComponentModel;

namespace Application.Domain.Entidades.Enums
{
    public enum CotacaoStatusEnum : byte
    {
        [Description("INICIALIZADA")]
        Inicializada = 1,

        [Description("Aceite")]
        Aceite = 2,

        [Description("Recusada")]
        Recusada = 3,

        [Description("Recusada")]
        Abandonada = 4,

        [Description("Recusada")]
        Finalizada = 5,

        [Description("PROPOSTA_GERADA")]
        PropostaGerada,

        [Description("PROPOSTA_ENVIADA")]
        PropostaEnviada,

        [Description("PROPOSTA_VENCIDA")]
        PropostaVencida,

        [Description("PROPOSTA_CANCELADA")]
        PropostaCancelada,

        [Description("PROPOSTA_ACEITA_DOCS_PENDENTE")]
        PropostaAceitaDocsPendente,

        [Description("DOCUMENTOS_PENDENTE_ANALISE")]
        DocumentosPendenteAnalise,

        [Description("DOCUMENTOS_EM_ANALISE")]
        DocumentosEmAnalise,

        [Description("DOCUMENTOS_INCONSISTENTES")]
        DocumentosInconsistentes,

        [Description("CLIENTE_RECUSADO")]
        ClienteRecusado,

        [Description("CLIENTE_ACEITO")]
        ClienteAceito,

        [Description("CLIENTE_IMPLANTADO")]
        ClienteImplantado
    }
}
