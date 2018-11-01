using Newtonsoft.Json;

namespace Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro.Contratos
{
    public abstract class I4ProRequisicaoBase
    {
        [JsonProperty(PropertyName = "nm_acao")]
        public virtual string Acao { get; set; }
        
        [JsonProperty(PropertyName = "cd_retorno")]
        public string CodigoRetorno { get; set; }
    }
}