using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.IntegracaoOdonto.Model
{
    public class OpcoesComissaoCorretorRetorno
    {
        public OpcoesComissaoCorretorRetorno() { }

        [JsonProperty("prospectoContratoComissaoOpcaoDTOList")]
        public List<ComissaoCorretor> OpcoesComissaoCorretor { get; set; }
    }

    public class ComissaoCorretor
    {
        public ComissaoCorretor() { }

        public int Id { get; set; }

        public double PercentualComissao { get; set; }

        public double PercentualVitalicio { get; set; }
    }
}
