using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.IntegracaoOdonto.Model
{
    public class PlanosRetorno
    {
        public PlanosRetorno()
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

        [JsonProperty("opcoesPlanos")]
        public List<OpcoesPlanos> OpcoesPlanos { get; set; }
    }

    public class OpcoesPlanos
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Descricao { get; set; }

        public string TipoContratacao { get; set; }

        public List<string> Coberturas { get; set; }

        public List<Valores> Valores { get; set; }
    }

    public class Valores
    {

        public string QuantidadeVidasAte { get; set; }

        public string QuantidadeVidasDe { get; set; }

        public string ValorPremioIndividual { get; set; }

        public string ValorPremioIndividualFmt { get; set; }
    }
}
