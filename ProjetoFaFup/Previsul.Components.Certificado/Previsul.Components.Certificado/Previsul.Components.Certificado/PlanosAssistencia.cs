using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.Certificado
{
    public class PlanosAssistencia
    {
        public PlanosAssistencia()
        {

        }

        public int id { get; set; }
        public int? idPlano { get; set; }
        public int? idAssistencia { get; set; }
        public string valor { get; set; }
        public DateTime? dataCriacao { get; set; }
        public bool? ativo { get; set; }
    }
}
