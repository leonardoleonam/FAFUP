using Newtonsoft.Json;

namespace Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro.Contratos
{
    public class I4ProEmissaoApoliceRetorno : I4ProRespostaRequisicaoBase
    {
        [JsonIgnore]
        public I4ProApolice Apolice { get; set; }
    }
}