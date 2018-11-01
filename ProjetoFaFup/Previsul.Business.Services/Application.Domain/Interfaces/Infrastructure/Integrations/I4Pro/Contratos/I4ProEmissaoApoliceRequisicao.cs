using Newtonsoft.Json;

namespace Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro.Contratos
{
    public class I4ProEmissaoApoliceRequisicao : I4ProRequisicaoBase
    {
        [JsonProperty(PropertyName = "nm_acao")]
        public override string Acao { get; set; } = "inserirapolice";

        [JsonProperty(PropertyName = "nm_conteudo_json")]
        public string ArquivoJson { get; set; }

        [JsonProperty(PropertyName = "nm_retorno")]
        public string DescricaoRetorno { get; set; }
    }
}
