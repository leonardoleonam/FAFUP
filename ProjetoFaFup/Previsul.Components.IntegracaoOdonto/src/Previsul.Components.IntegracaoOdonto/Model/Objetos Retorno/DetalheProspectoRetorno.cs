using Newtonsoft.Json;

namespace Previsul.Components.IntegracaoOdonto.Model
{
    public class DetalheProspectoRetorno
    {
        public DetalheProspectoRetorno()
        {

        }

        [JsonProperty("prospecto")]
        public Prospecto Prospecto { get; set; }       
    }
    
}
