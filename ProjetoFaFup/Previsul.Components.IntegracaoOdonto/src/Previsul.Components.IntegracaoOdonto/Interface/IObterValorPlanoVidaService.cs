using Previsul.Components.IntegracaoOdonto.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.IntegracaoOdonto.Interface
{
    interface IValorPlanoService
    {
        ValorPlanoRetorno ObterValorPlano(Dictionary<string, string> ObterValorPlanoRequisicao, bool isProduction);
    }
}
