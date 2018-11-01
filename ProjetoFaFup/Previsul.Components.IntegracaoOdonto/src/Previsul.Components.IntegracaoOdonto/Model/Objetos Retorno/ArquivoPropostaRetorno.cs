using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.IntegracaoOdonto.Model
{
    public class ArquivoPropostaRetorno
    {
        public ArquivoPropostaRetorno()
        {

        }

        [JsonProperty("data")]
        public DateTime Data { get; set; }

        [JsonProperty("descricaoStatus")]
        public string DescricaoStatus { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("conteudoArquivo")]
        public string ConteudoArquivo { get; set; }

        [JsonProperty("dataCriacao")]
        public DateTime DataCriacao;

        [JsonProperty("nomeArquivo")]
        public string NomeArquivo;        
        
    }
}
