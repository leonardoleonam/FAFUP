using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.Certificado
{
    public class PlanosCobertura
    {
        public PlanosCobertura()
        {

        }

        public int id { get; set; }
        public int? idPlano { get; set; }
        public int? idCobertura { get; set; }
        public decimal? valor { get; set; }
        public DateTime? dataCriacao { get; set; }
        public bool? ativo { get; set; }
    }
}
