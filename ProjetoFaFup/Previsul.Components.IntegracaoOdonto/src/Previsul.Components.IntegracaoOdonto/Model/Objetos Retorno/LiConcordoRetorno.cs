using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.IntegracaoOdonto.Model
{
    public class LiConcordoRetorno
    {
        public LiConcordoRetorno() { }

        public DateTime Data { get; set; }

        public string DescricaoStatus { get; set; }

        public string Status { get; set; }

        public string Conteudo { get; set; }
    }
}
