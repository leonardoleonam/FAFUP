using Application.Domain;
using Previsul.Components.IntegracaoI4PRO.Objetos_Requisicao;
using Previsul.Components.IntegracaoI4PRO.Objetos_Retorno;
using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.IntegracaoI4PRO.Interfaces
{
    public interface IProdutoCoberturaService
    {
        RetornoServico<I4ProProdutoCoberturaRetorno> Consultar(I4ProProdutoCoberturaRequisicao produtoCoberturaRequisicao);
    }
}
