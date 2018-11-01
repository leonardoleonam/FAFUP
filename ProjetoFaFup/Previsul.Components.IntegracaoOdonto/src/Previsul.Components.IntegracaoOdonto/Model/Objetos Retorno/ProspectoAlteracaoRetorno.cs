using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.IntegracaoOdonto.Model
{
    public class ProspectoAlteracaoRetorno
    {
        public ProspectoAlteracaoRetorno()
        {

        }

        [JsonProperty("data")]
        public DateTime Data { get; set; }

        [JsonProperty("descricaoStatus")]
        public string DescricaoStatus { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("numeroProposta")]
        public long NumeroProposta { get; set; }
    }
}
