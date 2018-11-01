using Newtonsoft.Json;

namespace Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro.Contratos
{
    public class I4ProGeradorDocumentosApoliceRequisicao
    {
        [JsonProperty(PropertyName = "anexardocumento")]
        public I4ProDocumento Anexar { get; set; }
    }
}
