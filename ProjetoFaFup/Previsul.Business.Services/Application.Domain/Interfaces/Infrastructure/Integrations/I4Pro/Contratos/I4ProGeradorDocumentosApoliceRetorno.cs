using Newtonsoft.Json;

namespace Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro.Contratos
{
    public class I4ProGeradorDocumentosApoliceRetorno : I4ProRespostaRequisicaoBase
    {
        [JsonProperty(PropertyName = "isSucess")]
        public bool Sucesso { get; set; }

        [JsonProperty(PropertyName = "executar")]
        public string Executar { get; set; }
    }
}
