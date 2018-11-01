using Previsul.Components.IntegracaoOdonto.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.IntegracaoOdonto.Interface
{
    interface IProspectoService
    {
        ProspectoRetorno IncluirProspecto(Prospecto Prospecto, bool isProduction);
    }
}
