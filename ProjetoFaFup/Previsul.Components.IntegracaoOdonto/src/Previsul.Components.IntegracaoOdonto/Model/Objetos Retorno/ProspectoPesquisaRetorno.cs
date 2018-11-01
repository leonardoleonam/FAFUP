using Newtonsoft.Json;
using System.Collections.Generic;

namespace Previsul.Components.IntegracaoOdonto.Model
{

    public class ProspectoPesquisaRetorno
    {
        public ProspectoPesquisaRetorno()
        {

        }

        [JsonProperty("primeiroRegistro")]
        public int PrimeiroRegistro;

        [JsonProperty("quantidadeMaxRegistros")]
        public int QuantidadeMaxRegistros;

        [JsonProperty("totalRegistros")]
        public int TotalRegistros;        

        [JsonProperty("itens")]
        public List<ProspectoPesquisa> Itens { get; set; }
    }   
}
