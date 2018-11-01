using Newtonsoft.Json;

namespace Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro.Contratos
{
    public class I4ProDocumento
    {
        [JsonProperty(PropertyName = "cd_apolice")]
        public string CodigoApolice { get; set; }

        [JsonProperty(PropertyName = "id_tp_documento")]
        public int IdentificadorTipo { get; set; }

        [JsonProperty(PropertyName = "id_dominio")]
        public int IdentificadorDominio { get; set; }

        [JsonProperty(PropertyName = "img_documento_arquivo")]
        public string ImagemArquivo { get; set; }

        [JsonProperty(PropertyName = "img_documento_content_type")]
        public string ImagemTipoCoonteudo { get; set; }

        [JsonProperty(PropertyName = "img_documento")]
        public string Imagem { get; set; }
    }
}
