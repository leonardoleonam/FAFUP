using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.IntegracaoOdonto.Model
{
    public class Mensagem
    {
        [JsonProperty("codigo")]
        public string Codigo;

        [JsonProperty("mensagem")]
        public string Descricao;
    }
}
