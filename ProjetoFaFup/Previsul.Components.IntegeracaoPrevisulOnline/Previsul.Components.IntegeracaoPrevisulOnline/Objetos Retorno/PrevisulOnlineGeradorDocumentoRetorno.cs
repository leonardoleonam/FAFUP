using Newtonsoft.Json;

namespace Application.Domain.Interfaces.Infrastructure.Integrations.PrevisulOnline.Contratos
{
    public class PrevisulOnlineGeradorDocumentoRetorno
    {
        [JsonProperty(PropertyName = "erroCode")]
        public int Erro { get; set; }

        [JsonProperty(PropertyName = "msg")]
        public string Mensagem { get; set; }

        [JsonProperty(PropertyName = "CONDICAO")]
        public string Condicao { get; set; }

        [JsonProperty(PropertyName = "PROPOSTA")]
        public string Proposta { get; set; }
    }
}
