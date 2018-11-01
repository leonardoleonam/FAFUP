using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.IntegracaoI4PRO.Objetos_Retorno
{
    //[JsonObject]
    public class I4ProProdutoCoberturaRetorno
    {
        public I4ProProdutoCoberturaRetorno()
        {

        }

        [JsonProperty(PropertyName = "cd_retorno")]
        public int CodigoRetorno { get; set; }

        [JsonProperty(PropertyName = "nm_retorno")]
        public string NomeRetorno { get; set; }

        [JsonProperty(PropertyName = "Produtos")]
        public List<ProdutoCobertura> ProdutoCoberturas { get; set; }
    }

    //[JsonObject]
    public class ProdutoCobertura
    {
        public ProdutoCobertura()
        {

        }

        [JsonProperty(PropertyName = "cd_produto")]
        public int Codigo { get; set; }

        [JsonProperty(PropertyName = "nm_produto")]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "nm_ramo")]
        public string Ramo { get; set; }

        [JsonProperty(PropertyName = "nr_idade_minima")]
        public int IdadeMinima { get; set; }

        [JsonProperty(PropertyName = "nr_idade_maxima")]
        public int IdadeMaxima { get; set; }

        [JsonProperty(PropertyName = "cd_externo")]
        public int CodigoExterno { get; set; }

        //[JsonProperty(PropertyName = "formaspagamento")]
        //public List<FormaPagamento> FormasPagamento { get; set; }

        //[JsonProperty(PropertyName = "formularios")]
        //public Formulario[] Formularios { get; set; }
    }

    [JsonArray]
    public class FormaPagamento
    {
        public FormaPagamento()
        {

        }

        [JsonProperty(PropertyName = "dados")]
        public List<Dados> Dados { get; set; }      
    }

    [JsonArray]
    public class Dados
    {
        public Dados()
        {

        }

        [JsonProperty(PropertyName = "cd_forma_pagamento")]
        public int CodigoFormaPagamento { get; set; }

        [JsonProperty(PropertyName = "ds_forma")]
        public string DescricaoFormaPagamento { get; set; }
    }

    [JsonArray]
    public class Formulario
    {
        public Formulario()
        {

        }

        [JsonProperty(PropertyName = "id_formulario")]
        public int IdFormulario { get; set; }

        [JsonProperty(PropertyName = "nm_formulario")]
        public string DescricaoFormulario { get; set; }
    }
}
