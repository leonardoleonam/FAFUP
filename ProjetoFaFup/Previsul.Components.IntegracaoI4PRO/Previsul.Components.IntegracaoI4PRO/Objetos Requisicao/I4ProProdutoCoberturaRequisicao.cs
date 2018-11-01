using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.IntegracaoI4PRO.Objetos_Requisicao
{
    public class I4ProProdutoCoberturaRequisicao
    {
        public I4ProProdutoCoberturaRequisicao()
        {

        }

        [JsonProperty(PropertyName = "cd_produto")]
        public int? CodigoProduto { get; set; }

        [JsonProperty(PropertyName = "cd_externo_produto")]
        public int? CodigoExternoProduto { get; set; }

        [JsonProperty(PropertyName = "cd_externo_cobertura")]
        public int? CodigoExternoCobertura { get; set; }

        [JsonProperty(PropertyName = "nr_cobertura")]
        public int NumeroCobertura { get; set; }

        [JsonProperty(PropertyName = "cd_retorno")]
        public int CodigoRetorno { get; set; }

        [JsonProperty(PropertyName = "nm_retorno")]
        public string NomeRetorno { get; set; }        
    }
}
