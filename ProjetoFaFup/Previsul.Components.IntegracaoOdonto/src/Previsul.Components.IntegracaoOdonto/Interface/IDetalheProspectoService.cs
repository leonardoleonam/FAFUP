using Previsul.Components.IntegracaoOdonto.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.IntegracaoOdonto.Interface
{
    interface IDetalheProspectoService
    {
        DetalheProspectoRetorno Detalhar(Dictionary<string, string> ObterProspectoRequisicao, bool isProduction);
    }
}
