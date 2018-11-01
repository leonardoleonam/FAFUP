using Previsul.Components.IntegracaoOdonto.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.IntegracaoOdonto.Interface
{
    interface IDiasVencimentoFaturaService
    {
        DiasVencimentoFaturaRetorno ListarDiasVencimentoFatura(bool isProduction);
    }
}
