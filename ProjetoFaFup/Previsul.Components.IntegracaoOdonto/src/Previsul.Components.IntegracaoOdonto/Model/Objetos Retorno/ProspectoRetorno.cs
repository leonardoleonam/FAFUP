using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.IntegracaoOdonto.Model
{
    public class ProspectoRetorno
    {
        public ProspectoRetorno()
        {
            Status = "ERRO";
            Data = DateTime.Now;
        }

        [JsonProperty("data")]
        public DateTime Data;

        [JsonProperty("descricaoStatus")]
        public string DescricaoStatus;

        [JsonProperty("mensagens")]
        public List<Mensagem> Mensagens;

        [JsonProperty("status")]
        public string Status;
       
        [JsonProperty("numeroProposta")]
        public string NumeroProposta;
    }

}
