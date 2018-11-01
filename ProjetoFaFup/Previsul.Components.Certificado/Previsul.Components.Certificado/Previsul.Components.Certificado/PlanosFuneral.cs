using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.Certificado
{
    public class PlanosFuneral
    {
        public PlanosFuneral()
        {

        }

        public int id { get; set; }
        public int? idPlano { get; set; }
        public int? idFuneral { get; set; }
        public decimal? valor { get; set; }
        public string descricao { get; set; }
        public DateTime? dataCriacao { get; set; }
        public bool? ativo { get; set; }
    }
}
