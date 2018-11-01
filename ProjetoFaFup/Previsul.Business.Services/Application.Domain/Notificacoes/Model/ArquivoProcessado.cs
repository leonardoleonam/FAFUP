using Application.Domain.Enums;
using System;

namespace Application.Domain.Notificacoes.Model
{
    public class ArquivoProcessado
    {
        public StatusPropostaArquivoEnum StatusProcessamentoArquivo { get; set; }

        public string StatusProcessamentoArquivoDescricao => StatusProcessamentoArquivo.ToDescriptionString();

        public string Mensagem { get; set; }

        public string Chave { get; set; }

        public string NumProposta { get; set; }

        public string NumApolice { get; set; }        

        public DateTime? DtEmissao { get; set; }

        public string DtEmissaoFormatada => DtEmissao != null ? DtEmissao.GetValueOrDefault().ToString("dd/MM/yyyy HH:mm:ss"): string.Empty;
    }
}
