using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Previsul.Components.IntegracaoOdonto.Model
{
    public class ValorPlanoRetorno
    {        
        public ValorPlanoRetorno() { }

        [JsonProperty("idPlanoOpcao")]
        public int IdPlanoOpcao { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("periodicidade")]
        public string Periodicidade { get; set; }

        [JsonProperty("valorDesconto")]
        public double ValorDesconto { get; set; }

        [JsonProperty("valorParcela")]
        public double ValorParcela { get; set; }

        [JsonProperty("valorPremio")]
        public double ValorPremio { get; set; }

        [JsonProperty("valorPremioIndividual")]
        public double ValorPremioIndividual { get; set; }

        [JsonProperty("valorTotal1Ano")]
        public double ValorTotal1Ano { get; set; }

        [JsonProperty("quantidadeVidasPlano")]
        public int QuantidadeVidasPlano;

        [JsonProperty("quantidadeVidasTotal")]
        public int QuantidadeVidasTotal;
    }
}
