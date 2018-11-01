using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.Certificado
{
    public class Produto
    {
        public Produto()
        {

        }

        public int id { get; set; }
        public string codigodoProduto { get; set; }
        public string nomedoSeguro { get; set; }
        public int? qtdRangeIdade { get; set; }
        public int? qtdPlanoPorRangeIdade { get; set; }
        public int? idTipoGeneroOferta { get; set; }
        public int? opcaoComissionamento { get; set; }
        public List<ProdutoComissionamento> comissionamentos { get; set; }
        public int? idTipoProduto { get; set; }
        public TipoProduto tipoProduto { get; set; }
        public int? idTipoPeriodicidade { get; set; }
        public TipoPeriodicidade tipoPeriodicidade { get; set; }
        public string coberturasTitulo { get; set; }
        public List<ProdutoCoberturas> coberturas { get; set; } //:[{}],
        public string funeraisTitulo { get; set; }
        public List<ProdutoFunerais> funerais { get; set; } //:[{}],
        public string assistenciasTitulo { get; set; }
        public List<ProdutoAssistencias> assistencias { get; set; } //:[{}],
        public List<ProdutoBeneficios> beneficios { get; set; } //:[{}],
        public List<ProdutoSorteios> sorteios { get; set; } //:[{}],
        public List<ProdutoObservacoes> observacoes { get; set; } //:[{}],
        public List<Planos> planos { get; set; } //:[{}],            
        public bool? solicitaDPSA { get; set; }
        public bool? ativo { get; set; }
        public DateTime? dataCriacao { get; set; }
        public bool? isValid { get; set; }
        public bool? isResidecial { get; set; }
        public List<Estipulante> estipulante { get; set; }
    }
}
