using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.Certificado
{
    public class PlanosRangedeIdade
    {
        public PlanosRangedeIdade()
        {

        }

        public int id { get; set; }
        public int? idPlano { get; set; }
        public int? idadeMin { get; set; }
        public int? idadeMax { get; set; }
        public int? idSexoPlano { get; set; }
        public decimal? valor { get; set; }
        public DateTime? dataCriacao { get; set; }
        public bool? ativo { get; set; }
    }
}
