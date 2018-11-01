using System;
using Application.Domain.Enums;

namespace Application.Domain.Notificacoes.Model
{
    public class PropostaProcessada
    {
        public StatusPropostaEnum StatusProposta { get; set; }

        public string StatusPropostaDescricao => StatusProposta.ToDescriptionString();

        public string Mensagem { get; set; }

        public string Chave { get; set; }

        public string NumProposta { get; set; }

        public string NumApolice { get; set; }

        public string NumContrato { get; set; }

        public DateTime? DtEmissao { get; set; }

        public string DtEmissaoFormatada => DtEmissao.GetValueOrDefault().ToString("dd/MM/yyyy HH:mm:ss");
    }
}
