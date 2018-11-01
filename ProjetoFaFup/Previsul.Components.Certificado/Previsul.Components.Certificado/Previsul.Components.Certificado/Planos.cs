using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.Certificado
{
    public class Planos
    {
        public Planos()
        {

        }

        public int id { get; set; }

        public int? idProduto { get; set; }

        public bool? ativo { get; set; }

        public int? idProdutoComissionamento { get; set; }

        public DateTime? dataCriacao { get; set; }

        public List<PlanosCobertura> planoCoberturas { get; set; }

        public List<PlanosFuneral> planoFunerais { get; set; }

        public List<PlanosAssistencia> planoAssistencias { get; set; }

        public List<PlanosBeneficio> planoBeneficios { get; set; }

        public List<PlanosRangedeIdade> planoRangedeIdade { get; set; }

        public List<PlanosSorteios> planoSorteios { get; set; }
    }
}
