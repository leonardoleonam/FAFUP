using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.Certificado
{
    public class PlanosBeneficio
    {
        public PlanosBeneficio()
        {

        }

        public int id { get; set; }
        public int? idPlano { get; set; }
        public int? idBeneficio { get; set; }
        public decimal? valor { get; set; }
        public DateTime? dataCriacao { get; set; }
        public bool? ativo { get; set; }
    }
}
