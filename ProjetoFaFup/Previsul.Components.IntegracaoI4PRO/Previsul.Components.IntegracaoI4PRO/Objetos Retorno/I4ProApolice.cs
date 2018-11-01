using System;
using Newtonsoft.Json;

namespace Application.Domain.Interfaces.Infrastructure.Integrations.I4Pro.Contratos
{
    public class I4ProApolice
    {
        [JsonProperty(PropertyName = "cd_apolice")]
        public string CodigoApolice { get; set; }

        [JsonProperty(PropertyName = "nr_contrato")]
        public string NumeroContrato { get; set; }

        [JsonProperty(PropertyName = "dt_emissao")]
        public DateTime DataEmissao { get; set; }
    }
}