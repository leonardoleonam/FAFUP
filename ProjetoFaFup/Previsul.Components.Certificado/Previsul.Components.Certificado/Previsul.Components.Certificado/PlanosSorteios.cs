using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.Certificado
{
    public class PlanosSorteios
    {
        public PlanosSorteios()
        {

        }

        public int id { get; set; }
        public int? idPlano { get; set; }
        public int? idSorteio { get; set; }
        public decimal? valor { get; set; }
        public DateTime? dataCriacao { get; set; }
        public bool? ativo { get; set; }
    }
}
