using Newtonsoft.Json;

namespace Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro.Contratos
{
    public abstract class I4ProRespostaRequisicaoBase
    {
        [JsonProperty(PropertyName = "nm_retorno")]
        public string Retorno { get; set; }

        [JsonProperty(PropertyName = "cd_retorno")]
        public int CodigoRetorno { get; set; }
    }
}