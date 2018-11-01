using Previsul.Components.IntegracaoOdonto.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Previsul.Components.IntegracaoOdonto.Interface
{
    interface IPlanoService
    {
        PlanosRetorno ListarPlanos(bool isProduction);
    }
}
